using GestorEmpleados.Domain.Entities;
using GestorEmpleados.Infrastructure.Exceptions;
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
    public class EmployeeStatusRepository : BaseRepository<EmployeeStatus>, IEmployeeStatus
    {

        private readonly EmployeeManagementDBContext _dbContext;
        private readonly ILogger<EmployeeRepository> _logger;


        public EmployeeStatusRepository(EmployeeManagementDBContext dbContext, ILogger<EmployeeRepository> logger) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._logger = logger;
        }

        public async Task<List<EmployeeStatus>> GetEmployeeStatuses()
        {
            try
            {
                var employeeStatuses = await (from e in _dbContext.EmployeeStatuses
                                              where e.Deleted == false
                                              select new EmployeeStatus
                                              {

                                                  EmployeeStatusId = e.EmployeeStatusId,
                                                  StatusName = e.StatusName,
                                                  Description = e.Description

                                              }).ToListAsync();

                return employeeStatuses;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error obteniendo los estados de los empleados, {ex.ToString()}.");
                throw new EmployeeExceptions("Ha ocurrido un error obteniendo estados de los empleados.");
            }
        }

    }
}
