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
    public class EmployeeTypeRepository : BaseRepository<EmployeeType>, IEmployeeType
    {

        private readonly EmployeeManagementDBContext _dbContext;
        private readonly ILogger<EmployeeRepository> _logger;


        public EmployeeTypeRepository(EmployeeManagementDBContext dbContext, ILogger<EmployeeRepository> logger) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._logger = logger;
        }

        public async Task<List<EmployeeTypeModel>> GetEmployeeTypes()
        {
            try
            {
                var employeeTypes = await (from et in _dbContext.EmployeeTypes
                                           where et.Deleted == false
                                           select new EmployeeTypeModel
                                           {
                                               EmployeeTypeId = et.EmployeeTypeId,
                                               TypeName = et.TypeName,
                                               Description = et.Description
                                           }).AsNoTracking().ToListAsync();

                return employeeTypes;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error obteniendo los tipos de empleados, {ex.ToString()}.");
                throw new EmployeeTypeExceptions("Ha ocurrido un error obteniendo los tipos de empleados.");
            }
        }
    }
}
