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
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Persistence.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRole
    {


        private readonly EmployeeManagementDBContext _dbContext;
        private readonly ILogger<EmployeeRepository> _logger;


        public RoleRepository(EmployeeManagementDBContext dbContext, ILogger<EmployeeRepository> logger) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._logger = logger;
        }

        public async Task<List<RoleModel>> GetRoleAll()
        {
            try
            {

                var roles = await (from r in _dbContext.Roles
                                   where r.Deleted == false
                                   select new RoleModel
                                   {
                                       RoleId = r.RoleId,
                                       RoleName = r.RoleName,
                                       Description = r.Description
                                   }).ToListAsync();

                return roles;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error obteniendo los roles, {ex.ToString()}.");
                throw new RoleExceptions("Ha ocurrido un error obteniendo los roles.");
            }
        }

        public async Task<RoleModel> GetRoleById(int Id)
        {
            try
            {
                var role = await (from r in _dbContext.Roles
                                  where r.RoleId == Id && r.Deleted == false
                                  select new RoleModel
                                  {
                                      RoleId = r.RoleId,
                                      RoleName = r.RoleName,
                                      Description = r.Description
                                  }).FirstOrDefaultAsync();
                return role;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error obteniendo el rol, {ex.ToString()}.");
                throw new RoleExceptions("Ha ocurrido un error obteniendo el rol.");
            }
        }

    }
}
