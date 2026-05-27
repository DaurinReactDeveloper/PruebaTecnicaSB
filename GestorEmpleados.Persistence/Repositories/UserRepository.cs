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
                throw new EmployeeExceptions("Ha ocurrido un error obteniendo el usuario.");
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
                throw new EmployeeExceptions("Ha ocurrido un error obteniendo los usuarios.");
            }
        }

    }
}
