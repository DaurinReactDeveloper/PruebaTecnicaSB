using GestorEmpleados.Application.Contract;
using GestorEmpleados.Application.Core;
using GestorEmpleados.Application.Dtos.EmployeeDto;
using GestorEmpleados.Application.Validations;
using GestorEmpleados.Domain.Entities;
using GestorEmpleados.Infrastructure.Extensions;
using GestorEmpleados.Persistence.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Services
{
    public class EmployeeServices : IEmployeeServices
    {

        private readonly IEmployee _employeeRepository;
        private readonly ILogger<EmployeeServices> _logger;

        public EmployeeServices(IEmployee employeeRepository, ILogger<EmployeeServices> logger)
        {
            this._employeeRepository = employeeRepository;
            this._logger = logger;
        }

        public async Task<ServiceResult> Add(EmployeeAddDto modelDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                List<string> validationErrors = EmployeeValidations.EmployeeValidation(modelDto);

                if (validationErrors.Any())
                {
                    result.Success = false;
                    result.Message = "Error de validación en los datos del empleado.";
                    result.Errors = validationErrors;
                    return result;
                }

                var employeeEntity = new Employee
                {
                    FirstName = modelDto.FirstName,
                    LastName = modelDto.LastName,
                    SocialSecurityNumber = modelDto.SocialSecurityNumber,
                    EmployeeTypeId = modelDto.EmployeeTypeId,
                    DepartmentId = modelDto.DepartmentId,
                    EmployeeStatusId = modelDto.EmployeeStatusId,
                    WeeklySalary = modelDto.WeeklySalary,
                    HourlyRate = modelDto.HourlyRate,
                    HoursWorked = modelDto.HoursWorked,
                    GrossSales = modelDto.GrossSales,
                    CommissionRate = modelDto.CommissionRate,
                    BaseSalary = modelDto.BaseSalary,
                    CreatedBy = modelDto.ChangeUser,
                    CreatedDate = DateTime.Now

                };

                await this._employeeRepository.Add(employeeEntity);

                result.Success = true;
                result.Message = "Empleado agregado correctamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el empleado.";
                this._logger.LogError($"Ha ocurrido un error guardando el empleado: {ex.Message}.");
            }

            return result;
        }

        public async Task<ServiceResult> GetEmployeeByFilter(string name, int? departmentId, int? employeeStatusId)
        {

            ServiceResult result = new ServiceResult();

            try
            {

                var employees = await this._employeeRepository.GetEmployeeByFilter(name, departmentId, employeeStatusId);

                if (EmployeeValidations.IsInvalidEmployeeList(employees))
                {

                    result.Success = false;
                    result.Message = "No se encontraron empleados con los filtros proporcionados.";
                    return result;

                }

                result.Data = employees;
                result.Message = "Empleados obtenidos correctamente.";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los empleados.";
                this._logger.LogError($"Ha ocurrido un error obteniendo los empleados: {ex.Message}.");
            }

            return result;
        }

        public async Task<ServiceResult> GetEmployeeById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                var employee = await this._employeeRepository.GetEmployeeById(id);

                if (EmployeeValidations.IsNullEmployee(employee))
                {
                    result.Success = false;
                    result.Message = "No se encontró el empleado con el ID proporcionado.";
                    return result;
                }

                result.Data = employee;
                result.Message = "Empleado obtenido correctamente.";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obtiendo el empleado.";
                this._logger.LogError($"Ha ocurrido un error obteniendo el empleado: {ex.Message}.");
            }

            return result;

        }

        public async Task<ServiceResult> GetEmployees()
        {

            ServiceResult result = new ServiceResult();

            try
            {

                var employees = await this._employeeRepository.GetEmployees();

                if (EmployeeValidations.IsInvalidEmployeeList(employees))
                {
                    result.Success = false;
                    result.Message = "No se encontraron empleados.";
                    return result;
                }


                result.Data = employees;
                result.Message = "Empleados obtenidos correctamente.";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obtiendo los empleados.";
                this._logger.LogError($"Ha ocurrido un error obteniendo los empleados: {ex.Message}.");
            }

            return result;
        }

        public async Task<ServiceResult> Remove(EmployeeRemoveDto modelDto)
        {

            ServiceResult result = new ServiceResult();

            try
            {

                if (EmployeeValidations.IsInvalidEmployeeId(modelDto))
                {
                    result.Success = false;
                    result.Message = "Debe proporcionar el ID del empleado.";
                    return result;
                }

                var employee = await this._employeeRepository.GetEmployeeById(modelDto.EmployeeId);

                if (EmployeeValidations.IsNullEmployee(employee))
                {
                    result.Success = false;
                    result.Message = "No se encontró el empleado con el ID proporcionado.";
                    return result;
                }

                var employeDelete = EmployeeExtensions.EmployeeModelToEntity(employee);

                employeDelete.DeletedBy = modelDto.ChangeUser;

                await this._employeeRepository.Remove(employeDelete);

                result.Message = "Empleado eliminado correctamente.";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el empleado.";
                this._logger.LogError($"Ha ocurrido un error eliminando el empleado: {ex.Message}.");
            }

            return result;

        }

        public async Task<ServiceResult> Update(EmployeeUpdateDto modelDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                if (EmployeeValidations.IsInvalidEmployeeId(modelDto))
                {
                    result.Success = false;
                    result.Message = "Debe proporcionar el ID del empleado.";
                    return result;
                }

                var employee = await this._employeeRepository.GetEmployeeById(modelDto.EmployeeId);

                if (EmployeeValidations.IsNullEmployee(employee))
                {
                    result.Success = false;
                    result.Message = "No se encontró el empleado con el ID proporcionado.";
                    return result;
                }

                List<string> validationErrors = EmployeeValidations.EmployeeValidation(modelDto);

                if (validationErrors.Any())
                {
                    result.Success = false;
                    result.Message = "Error de validación en los datos actualizados del empleado.";
                    result.Errors = validationErrors;
                    return result;
                }

                var employeeUpdate = EmployeeExtensions.EmployeeModelToEntity(employee);
                employeeUpdate.ModifiedBy = modelDto.ChangeUser;
                employeeUpdate.ModifiedDate = DateTime.Now;

                await this._employeeRepository.Update(employeeUpdate);

                result.Message = "Empleado actualizado correctamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando el empleado.";
                this._logger.LogError($"Ha ocurrido un error actualizando el empleado: {ex.Message}.");
            }

            return result;
        }

    }
}
