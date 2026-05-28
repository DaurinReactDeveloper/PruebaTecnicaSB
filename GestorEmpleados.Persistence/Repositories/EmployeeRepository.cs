using GestorEmpleados.Domain.Entities;
using GestorEmpleados.Infrastructure.Exceptions;
using GestorEmpleados.Infrastructure.Models;
using GestorEmpleados.Persistence.Context;
using GestorEmpleados.Persistence.Core;
using GestorEmpleados.Persistence.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployee
    {

        private readonly EmployeeManagementDBContext _dbContext;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(EmployeeManagementDBContext dbContext, ILogger<EmployeeRepository> logger) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._logger = logger;
        }

        public async Task<List<Vw_EmployeModel>> GetEmployees()
        {

            try
            {
                var employees = await _dbContext.VwEmployeeDetails
               .Where(e => e.Deleted == false)
               .Select(e => new Vw_EmployeModel
               {
                   EmployeeId = e.EmployeeId,
                   FirstName = e.FirstName,
                   LastName = e.LastName,
                   FullName = e.FullName,
                   SocialSecurityNumber = e.SocialSecurityNumber,
                   EmployeeTypeId = e.EmployeeTypeId,
                   EmployeeTypeName = e.EmployeeTypeName,
                   DepartmentId = e.DepartmentId,
                   DepartmentName = e.DepartmentName,
                   EmployeeStatusId = e.EmployeeStatusId,
                   StatusName = e.StatusName,
                   WeeklySalary = e.WeeklySalary,
                   HourlyRate = e.HourlyRate,
                   HoursWorked = e.HoursWorked,
                   GrossSales = e.GrossSales,
                   CommissionRate = e.CommissionRate,
                   BaseSalary = e.BaseSalary
               })
               .ToListAsync();

                return employees;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error obteniendo los empleados, {ex.ToString()}.");
                throw new EmployeeExceptions("Ha ocurrido un error obteniendo los empleados.");
            }
        }

        public async Task<EmployeeModel> GetEmployeeById(int id)
        {
            try
            {
                var employees = await (from e in _dbContext.Employees
                                       where e.Deleted == false && e.EmployeeId == id
                                       select new EmployeeModel
                                       {
                                           EmployeeId = e.EmployeeId,
                                           FirstName = e.FirstName,
                                           LastName = e.LastName,
                                           SocialSecurityNumber = e.SocialSecurityNumber,
                                           EmployeeTypeId = e.EmployeeTypeId,
                                           DepartmentId = e.DepartmentId,
                                           EmployeeStatusId = e.EmployeeStatusId,
                                           WeeklySalary = e.WeeklySalary,
                                           HourlyRate = e.HourlyRate,
                                           HoursWorked = e.HoursWorked,
                                           GrossSales = e.GrossSales,
                                           CommissionRate = e.CommissionRate,
                                           BaseSalary = e.BaseSalary

                                       }).FirstOrDefaultAsync();

                return employees;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Ha ocurrido un error obteniendo el empleado, {ex.ToString()}.");
                throw new EmployeeExceptions("Ha ocurrido un error obteniendo obteniendo el empleado.");

            }
        }

        public async Task<List<EmployeeModel>> GetEmployeeByFilter(string name, int? departmentId, int? employeeStatusId)
        {
            try
            {
                var paramName = new SqlParameter("@Name", (object)name ?? DBNull.Value);
                var paramDepartment = new SqlParameter("@DepartmentID", (object)departmentId ?? DBNull.Value);
                var paramStatus = new SqlParameter("@EmployeeStatusID", (object)employeeStatusId ?? DBNull.Value);

                var filteredEmployees = await _dbContext.Database
                    .SqlQuery<EmployeeModel>(
                        $"EXEC sp_GetEmployees @Name={paramName}, @DepartmentID={paramDepartment}, @EmployeeStatusID={paramStatus}"
                    )
                    .ToListAsync();

                return filteredEmployees;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error al filtrar los empleados mediante procedimiento, {ex.ToString()}.");
                throw new EmployeeExceptions("Ha ocurrido un error al aplicar los filtros de empleados.");
            }
        }

        public override async Task Add(Employee entity)
        {
            try
            {
                await base.Add(entity);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error guardando el empleado, {ex.ToString()}.");
                throw new EmployeeExceptions("Ha ocurrido un error guardando el empleado.");
            }
        }

        public override async Task Remove(Employee entity)
        {
            try
            {
                var employee = await base.GetById(entity.EmployeeId);

                if (employee is null || employee.Deleted)
                {
                    throw new EmployeeExceptions("Ha ocurrido un error obteniendo el empleado.");
                }

                employee.Deleted = true;
                employee.DeletedDate = DateTime.Now;
                employee.DeletedBy = entity.DeletedBy;

                await base.Update(employee);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error eliminando el empleado, {ex.ToString()}.");
                throw new EmployeeExceptions("Ha ocurrido un error eliminando el empleado.");
            }
        }

        public override async Task Update(Employee entity)
        {
            try
            {
                var empleadoUpdate = await base.GetById(entity.EmployeeId);

                if (empleadoUpdate is null || empleadoUpdate.Deleted)
                {
                    throw new EmployeeExceptions("Ha ocurrido un error obteniendo el empleado.");
                }

                empleadoUpdate.FirstName = entity.FirstName;
                empleadoUpdate.LastName = entity.LastName;
                empleadoUpdate.SocialSecurityNumber = entity.SocialSecurityNumber;
                empleadoUpdate.EmployeeStatusId = entity.EmployeeStatusId;
                empleadoUpdate.GrossSales = entity.GrossSales;
                empleadoUpdate.HourlyRate = entity.HourlyRate;
                empleadoUpdate.HoursWorked = entity.HoursWorked;
                empleadoUpdate.WeeklySalary = entity.WeeklySalary;
                empleadoUpdate.CommissionRate = entity.CommissionRate;


                await base.Update(empleadoUpdate);
                await base.SaveChanges();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error actualizando el empleado, {ex.ToString()}.");
                throw new EmployeeExceptions("Ha ocurrido un error actualizando el empleado.");

            }
        }

        public async Task<List<PayrollEmployeeModel>> GetPayroll(int? employeeId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var paramId = new SqlParameter("@EmployeeID", (object)employeeId ?? DBNull.Value);
                var paramStartDate = new SqlParameter("@StartDate", startDate);
                var paramEndDate = new SqlParameter("@EndDate", endDate);

                var payrollEmployees = await _dbContext.Database
                    .SqlQuery<PayrollEmployeeModel>(
                        $"EXEC sp_CalculateWeeklyPayroll @StartDate={paramStartDate}, @EndDate={paramEndDate}, @EmployeeID={paramId}"
                    )
                    .ToListAsync();

                return payrollEmployees;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error al procesar la nómina desde el procedimiento: {ex.ToString()}");
                throw new EmployeeExceptions("Ha ocurrido un error en el motor de base de datos al procesar la nómina.");
            }
        }
        public async Task<EmployeeModel> GetEmployeeBySSN(string SocialSecurityNumber)
        {
            try
            {
                var employee = await (from e in _dbContext.Employees
                                      where e.Deleted == false && e.SocialSecurityNumber.Equals(SocialSecurityNumber)
                                      select new EmployeeModel
                                      {
                                          FirstName = e.FirstName,
                                          LastName = e.LastName,
                                          SocialSecurityNumber = e.SocialSecurityNumber,
                                          EmployeeId = e.EmployeeId,
                                          
                                      }).FirstOrDefaultAsync();

                return employee;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error al obtener el empleado por su SSN, {ex.ToString()}.");
                throw new EmployeeExceptions("Ha ocurrido un error al obtener el empleado por su SSN.");
            }
        }
    }
}
