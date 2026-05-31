using GestorEmpleados.Application.Contract;
using GestorEmpleados.Application.Core;
using GestorEmpleados.Application.Dtos.UserDto;
using GestorEmpleados.Application.Validations;
using GestorEmpleados.Domain.Entities;
using GestorEmpleados.Infrastructure.Extensions;
using GestorEmpleados.Persistence.Interfaces;
using GestorEmpleados.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Services
{
    public class UserServices : IUserServices
    {

        private readonly IUser _userRepository;
        private readonly IPasswordHashServices _passwordHashServices;
        private readonly ILogger<UserServices> _logger;

        public UserServices(IUser userRepository, ILogger<UserServices> logger, IPasswordHashServices passwordHashServices)
        {
            this._userRepository = userRepository;
            this._logger = logger;
            _passwordHashServices = passwordHashServices;
        }

        public async Task<ServiceResult> GetUserByEmail(string email)
        {

            ServiceResult result = new ServiceResult();

            try
            {

                if (UserValidations.IsInvalidEmail(email))
                {

                    result.ResultType = MessageType.Warning;
                    result.Message = "El correo electrónico no puede ser nulo.";
                    return result;

                }

                var user = await this._userRepository.GetUserByEmail(email);

                if (UserValidations.IsInvalidVmUser(user))
                {
                    result.ResultType = MessageType.NotFound;
                    result.Message = "No se encontró un usuario con el correo electrónico proporcionado.";
                    return result;
                }

                user.PasswordHash = "";
                result.Data = user;
                result.Message = "Usuario obtenido correctamente.";

            }
            catch (Exception ex)
            {
                result.ResultType = MessageType.Error;
                result.Message = "Error obteniendo el usuario.";
                this._logger.LogError($"Ha ocurrido un error obteniendo el usuario: {ex.Message}."); ;
            }

            return result;

        }

        public async Task<ServiceResult> GetUsers()
        {

            ServiceResult result = new ServiceResult();

            try
            {

                var users = await this._userRepository.GetUsers();

                if (UserValidations.IsInvalidUserList(users))
                {
                    result.ResultType = MessageType.NotFound;
                    result.Message = "No se encontraron usuarios en el sistema.";
                    return result;
                }

                result.Data = users;
                result.Message = "Usuarios obtenidos correctamente.";

            }
            catch (Exception ex)
            {

                result.ResultType = MessageType.Error;
                result.Message = "Error obteniendo los usuarios.";
                this._logger.LogError($"Ha ocurrido un error obteniendo los usuarios: {ex.Message}."); ;
            }

            return result;
        }

        public async Task<ServiceResult> Login(string email, string password)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (UserValidations.IsInvalidEmail(email) || string.IsNullOrWhiteSpace(password))
                {
                    result.ResultType = MessageType.Warning;
                    result.Message = "El correo electrónico y la contraseña son obligatorios.";
                    return result;
                }

                var user = await this._userRepository.GetUserByEmail(email);

                if (UserValidations.IsInvalidVmUser(user))
                {
                    result.ResultType = MessageType.NotFound;
                    result.Message = "Correo electrónico o contraseña incorrectos.";
                    return result;
                }

                var verifiedPassword = this._passwordHashServices.VerifyPassword(password, user.PasswordHash);

                if (!verifiedPassword)
                {
                    result.ResultType = MessageType.Warning;
                    result.Message = "Correo electrónico o contraseña incorrectos.";
                    return result;
                }

                user.PasswordHash = "";
                result.Data = user;
                result.Message = "Autenticación exitosa.";
            }
            catch (Exception ex)
            {
                result.ResultType = MessageType.Error;
                result.Message = "Ocurrió un error al intentar iniciar sesión.";
                this._logger.LogError($"Ha ocurrido un error en el proceso de Login: {ex.Message}.");
            }

            return result;
        }

        public async Task<ServiceResult> Add(UserAddDto modelDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                List<string> validationErrors = UserValidations.ValidateUser(modelDto);

                if (validationErrors.Any())
                {
                    result.ResultType = MessageType.Warning;
                    result.Message = "Error de validación en los datos del usuario.";
                    result.Errors = validationErrors;
                    return result;
                }

                var existingUser = await this._userRepository.GetUserByEmail(modelDto.Email);

                if (UserValidations.UserExists(existingUser))
                {
                    result.ResultType = MessageType.Warning;
                    result.Message = "El correo electrónico ya se encuentra registrado en el sistema.";
                    return result;
                }

                string passwordHash = this._passwordHashServices.HashPassword(modelDto.PasswordHash);

                var userEntity = new User
                {
                    EmployeeId = modelDto.EmployeeId,
                    Email = modelDto.Email,
                    Username = modelDto.Username,
                    PasswordHash = passwordHash,
                    RoleId = modelDto.RoleId,
                    CreatedBy = modelDto.ChangeUser,
                    CreatedDate = DateTime.Now
                };

                await this._userRepository.Add(userEntity);
                result.Message = "Usuario guardado correctamente.";

            }
            catch (Exception ex)
            {
                result.ResultType = MessageType.Error;
                result.Message = "Error guardando el usuario.";
                this._logger.LogError($"Ha ocurrido un error guardando el usuario: {ex.Message}.");
            }

            return result;
        }

        public async Task<ServiceResult> Remove(UserRemoveDto modelDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (UserValidations.IsInvalidUserId(modelDto))
                {
                    result.ResultType = MessageType.Warning;
                    result.Message = "Debe proporcionar el ID del usuario.";
                    return result;
                }

                var user = await this._userRepository.GetUserById(modelDto.UserId);

                if (UserValidations.IsNullUser(user))
                {
                    result.ResultType = MessageType.NotFound;
                    result.Message = "No se encontró un usuario con el ID proporcionado.";
                    return result;
                }

                var userDelete = UserExtensions.UserModelToEntity(user);
                userDelete.DeletedBy = modelDto.ChangeUser;

                await this._userRepository.Remove(userDelete);
                result.Message = "Usuario eliminado correctamente.";

            }
            catch (Exception ex)
            {
                result.ResultType = MessageType.Error;
                result.Message = "Error eliminando el usuario.";
                this._logger.LogError($"Ha ocurrido un error eliminando el usuario: {ex.Message}.");
            }

            return result;

        }

        public async Task<ServiceResult> Update(UserUpdateDto modelDto)
        {

            ServiceResult result = new ServiceResult();

            try
            {

                if(UserValidations.IsInvalidUserId(modelDto))
                {
                    result.ResultType = MessageType.Warning;
                    result.Message = "Debe proporcionar el ID del usuario.";
                    return result;
                }

                var user = await this._userRepository.GetUserById(modelDto.UserId);

                if (UserValidations.IsNullUser(user))
                {
                    result.ResultType = MessageType.NotFound;
                    result.Message = "No se encontró un usuario con el ID proporcionado.";
                    return result;
                }

                List<string> validationErrors = UserValidations.ValidateUser(modelDto);

                if (validationErrors.Any())
                {
                    result.ResultType = MessageType.Warning;
                    result.Message = "Error de validación en los datos actualizados del usuario.";
                    result.Errors = validationErrors;
                    return result;
                }

                string passwordHash = this._passwordHashServices.HashPassword(modelDto.PasswordHash);

                var userUpdate = UserExtensions.UserModelToEntity(user);
                userUpdate.ModifiedBy = modelDto.ChangeUser;
                userUpdate.ModifiedDate = DateTime.Now;
                userUpdate.RoleId = modelDto.RoleId;
                userUpdate.Email = modelDto.Email;
                userUpdate.Username = modelDto.Username;
                userUpdate.PasswordHash = passwordHash;

                await this._userRepository.Update(userUpdate);
                result.Message = "Usuario actualizado correctamente.";

            }
            catch (Exception ex)
            {
                result.ResultType = MessageType.Error;
                result.Message = "Error actualizando el usuario.";
                this._logger.LogError($"Ha ocurrido un error actualizando el usuario: {ex.Message}.");
            }

            return result;

        }
   
    }
}
