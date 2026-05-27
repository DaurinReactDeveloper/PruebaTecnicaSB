using GestorEmpleados.Application.Contract;
using GestorEmpleados.Application.Core;
using GestorEmpleados.Application.Validations;
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
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartment _repositoryDepartment;
        private readonly ILogger<DepartmentServices> _logger;

        public DepartmentServices(IDepartment repositoryDepartment, ILogger<DepartmentServices> logger)
        {
            this._repositoryDepartment = repositoryDepartment;
            this._logger = logger;
        }

        public async Task<ServiceResult> GetDepartments()
        {

            ServiceResult result = new ServiceResult();

            try
            {
                var departments = await _repositoryDepartment.GetDepartments();

                if (!DeparmentValidations.GetDepartmentValidation(departments))
                {
                    result.Success = false;
                    result.Message = "No se encontraron departamentos";
                    return result;
                }

                result.Data = departments;
                result.Message = "Departamentos obtenidos correctamente";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los departamentos.";
                this._logger.LogError($"Ha ocurrido un error obteniendo los departamentos: {ex.Message}.");
            }

            return result;

        }

    }
}
