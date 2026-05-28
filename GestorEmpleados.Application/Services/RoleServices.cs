using GestorEmpleados.Application.Contract;
using GestorEmpleados.Application.Core;
using GestorEmpleados.Application.Validations;
using GestorEmpleados.Persistence.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Services
{
    public class RoleServices : IRoleServices
    {

        private readonly IRole _roleRepository;
        private readonly ILogger<RoleServices> _logger;

        public RoleServices(IRole roleRepository, ILogger<RoleServices> logger)
        {
            this._roleRepository = roleRepository;
            this._logger = logger;
        }

        public async Task<ServiceResult> GetRoleAll()
        {

            ServiceResult result = new ServiceResult();

            try
            {
                var role = await this._roleRepository.GetRoleAll();

                if (RolValidations.IsNullRoles(role))
                {
                    result.ResultType = MessageType.NotFound;
                    result.Message = "No se encontraron roles.";
                    return result;
                }

                result.Data = role;
                result.Message = "Roles encontrados exitosamente.";

            }
            catch (Exception ex)
            {
                result.ResultType = MessageType.Error;
                result.Message = "Error obteniendo los roles.";
                this._logger.LogError($"Ha ocurrido un error obteniendo los roles: {ex.Message}.");
            }

            return result;

        }

        public async Task<ServiceResult> GetRoleById(int id)
        {

            ServiceResult result = new ServiceResult();

            try
            {

                if(!RolValidations.IsValidRoleId(id))
                {
                    result.ResultType = MessageType.Warning;
                    result.Message = "Debe proporcionar el ID del rol.";
                    return result;
                }

                var role = await this._roleRepository.GetRoleById(id);

                if (RolValidations.IsNullRole(role))
                {
                    result.ResultType = MessageType.NotFound;
                    result.Message = "No se encontró el rol.";
                    return result;
                }

                result.Data = role;
                result.Message = "Rol encontrado exitosamente.";

            }
            catch (Exception ex)
            {
                result.ResultType = MessageType.Error;
                result.Message = "Error obteniendo el rol.";
                this._logger.LogError($"Ha ocurrido un error obteniendo el rol: {ex.Message}.");
            }

            return result;
        }
    
    }
}
