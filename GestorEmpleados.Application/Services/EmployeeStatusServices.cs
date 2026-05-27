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
    public class EmployeeStatusServices : IEmployeeStatusServices
    {

        private readonly IEmployeeStatus _employeeStatusRepository;
        private readonly ILogger<EmployeeStatusServices> _logger;

        public EmployeeStatusServices(IEmployeeStatus employeeStatusRepository, ILogger<EmployeeStatusServices> logger)
        {
            this._employeeStatusRepository = employeeStatusRepository;
            this._logger = logger;
        }

        public async Task<ServiceResult> GetEmployeeStatuses()
        {

            ServiceResult result = new ServiceResult();

            try
            {
                var employeeStatuses = await _employeeStatusRepository.GetEmployeeStatuses();

                if (EmployeeStatusValidations.IsNullEmployeeStatus(employeeStatuses)) {

                    result.Success = false;
                    result.Message = "No se encontraron estados de empleados.";
                    return result;
  
                }

                result.Data = employeeStatuses;
                result.Message = "Estados de empleados obtenidos exitosamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los estados de los empleados.";
                this._logger.LogError($"Ha ocurrido un error obteniendo los estados de los empleados: {ex.Message}.");
            }

            return result;
        }
    }
}
