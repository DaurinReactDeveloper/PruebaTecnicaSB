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
    public class DepartmentRepository : BaseRepository<Department>, IDepartment
    {

        private readonly EmployeeManagementDBContext _dbContext;
        private readonly ILogger<EmployeeRepository> _logger;


        public DepartmentRepository(EmployeeManagementDBContext dbContext, ILogger<EmployeeRepository> logger) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._logger = logger;
        }

        public async Task<List<Department>> GetDepartments()
        {

            try
            {

                var departments = await (from d in _dbContext.Departments
                                         where d.Deleted == false
                                         select new Department
                                         {
                                             DepartmentId = d.DepartmentId,
                                             DepartmentName = d.DepartmentName,
                                             Description = d.Description

                                         }).ToListAsync();

                return departments;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error obteniendo los departamentos, {ex.ToString()}.");
                throw new EmployeeExceptions("Ha ocurrido un error obteniendo los departamentos.");
            }

        }

    }
}
