using GestorEmpleados.Domain.Entities;
using GestorEmpleados.Infrastructure.Exceptions;
using GestorEmpleados.Infrastructure.Models;
using GestorEmpleados.Persistence.Context;
using GestorEmpleados.Persistence.Core;
using GestorEmpleados.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUser
    {

        private readonly EmployeeManagementDBContext _dbContext;
        private readonly ILogger<EmployeeRepository> _logger;


        public UserRepository(EmployeeManagementDBContext dbContext, ILogger<EmployeeRepository> logger) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._logger = logger;
        }

        public async Task<UserModel> GetUserByGmail(string email)
        {

            try
            {
                var user = await (from u in _dbContext.Users
                                  where u.Email == email && u.Deleted == false
                                  select new UserModel
                                  {
                                      UserId = u.UserId,
                                      EmployeeId = u.EmployeeId,
                                      Email = u.Email,
                                      Username = u.Username,
                                      PasswordHash = u.PasswordHash,
                                      RoleId = u.RoleId
                                  }).FirstOrDefaultAsync();

                return user;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error obteniendo el usuario, {ex.ToString()}.");
                throw new UserExceptions("Ha ocurrido un error obteniendo el usuario.");
            }

        }

        public async Task<List<UserModel>> GetUsers()
        {
            try
            {
                var user = await (from u in _dbContext.Users
                                  where u.Deleted == false
                                  select new UserModel
                                  {
                                      UserId = u.UserId,
                                      EmployeeId = u.EmployeeId,
                                      Email = u.Email,
                                      Username = u.Username,
                                      PasswordHash = u.PasswordHash,
                                      RoleId = u.RoleId
                                  }).ToListAsync();

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error obteniendo los usuarios, {ex.ToString()}.");
                throw new UserExceptions("Ha ocurrido un error obteniendo los usuarios.");
            }
        }

        public async Task<UserModel> GetUserById(int id)
        {
            try
            {
                var user = await (from u in _dbContext.Users
                                  where u.UserId == id && u.Deleted == false
                                  select new UserModel
                                  {
                                      UserId = u.UserId,
                                      EmployeeId = u.EmployeeId,
                                      Email = u.Email,
                                      Username = u.Username,
                                      RoleId = u.RoleId

                                  }).FirstOrDefaultAsync();
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error obteniendo el usuario, {ex.ToString()}.");
                throw new UserExceptions("Ha ocurrido un error obteniendo el usuario.");
            }
        }

        public override async Task Add(User entity)
        {
            try
            {
                await base.Add(entity);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error guardando el usuario, {ex.ToString()}.");
                throw new UserExceptions("Ha ocurrido un error guardando el usuario.");
            }
        }

        public override async Task Update(User entity)
        {
            try
            {
                var userUpdate = await base.GetById(entity.EmployeeId);

                if (userUpdate is null || userUpdate.Deleted)
                {
                    throw new EmployeeExceptions("Ha ocurrido un error obteniendo el usuario.");
                }

                userUpdate.Role = entity.Role;
                userUpdate.Email = entity.Email;
                userUpdate.Username = entity.Username;
                userUpdate.PasswordHash = entity.PasswordHash;

                await base.Update(userUpdate);
                await base.SaveChanges();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error actualizando el empleado, {ex.ToString()}.");
                throw new EmployeeExceptions("Ha ocurrido un error actualizando el empleado.");
            }
        }

        public override async Task Remove(User entity)
        {
            try
            {
                var user = await base.GetById(entity.EmployeeId);
                if (user is null || user.Deleted)
                {
                    throw new UserExceptions("Ha ocurrido un error obteniendo el usuario.");
                }
                user.Deleted = true;
                await base.Update(user);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error eliminando el usuario, {ex.ToString()}.");
                throw new UserExceptions("Ha ocurrido un error eliminando el usuario.");
            }

        }
    
    }
}
