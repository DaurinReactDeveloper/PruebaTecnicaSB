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
    public class EmployeeTypeServices : IEmployeeTypeServices
    {

        private readonly IEmployeeType _employeeTypeRepository;
        private readonly ILogger<EmployeeTypeServices> _logger;

        public EmployeeTypeServices(IEmployeeType employeeTypeRepository, ILogger<EmployeeTypeServices> logger)
        {
            this._employeeTypeRepository = employeeTypeRepository;
            this._logger = logger;
        }

        public async Task<ServiceResult> GetEmployeeTypes()
        {

            ServiceResult result = new ServiceResult();

            try
            {

                var employeeTypes = await this._employeeTypeRepository.GetEmployeeTypes();

                if (EmployeeTypeValidations.IsNullEmployeeType(employeeTypes))
                {

                    result.Success = false;
                    result.Message = "No se han encontrado tipos de empleados.";
                    return result;

                }

                result.Data = employeeTypes;
                result.Message = "Tipos de empleados obtenidos correctamente.";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los tipos de empleados.";
                this._logger.LogError($"Ha ocurrido un error obteniendo los tipos de empleados: {ex.Message}.");
            }

            return result;

        }

    }
}
