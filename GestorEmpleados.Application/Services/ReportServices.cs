using GestorEmpleados.Application.Contract;
using GestorEmpleados.Application.Core;
using GestorEmpleados.Application.Dtos.PayrollResultDto;
using GestorEmpleados.Application.Validations;
using GestorEmpleados.Domain.Entities;
using GestorEmpleados.Persistence.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Services
{
    public class ReportServices : IReportServices
    {
        private readonly IEmployee _employeeRepository;
        private readonly ILogger<ReportServices> _logger;

        public ReportServices(IEmployee employeeRepository, ILogger<ReportServices> logger)
        {
            this._employeeRepository = employeeRepository;
            this._logger = logger;
        }

        // Reporte semanal de nómina para todos los empleados registrados
        public async Task<ServiceResult> GenerateWeeklyPayrollReport()
        {
            ServiceResult result = new ServiceResult();
            var reportData = new List<PayrollResultDto>();

            try
            {
                var employees = await this._employeeRepository.GetPayroll(null);

                if (employees == null || !employees.Any())
                {
                    result.ResultType = MessageType.NotFound;
                    result.Message = "No hay empleados registrados para generar el reporte.";
                    return result;
                }

                foreach (var emp in employees)
                {
                    reportData.Add(new PayrollResultDto
                    {
                        EmployeeId = emp.EmployeeId,
                        FullName = $"{emp.FirstName} {emp.LastName}",
                        EmployeeTypeId = emp.EmployeeTypeId,
                        WeeklyPayment = emp.CalculatedPayment
                    });
                }

                result.Data = reportData;
                result.Message = $"Reporte semanal generado exitosamente. Total de empleados procesados: {reportData.Count}.";
            }
            catch (Exception ex)
            {
                result.ResultType = MessageType.Error;
                result.Message = "Error generando el reporte semanal de nómina.";
                this._logger.LogError($"Error en GenerateWeeklyPayrollReport: {ex.Message}");
            }

            return result;
        }

        // Cálculo del pago semanal para un empleado específico
        public async Task<ServiceResult> CalculateWeeklyPayroll(int employeeId)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var employees = await this._employeeRepository.GetPayroll(employeeId);
                var employee = employees?.FirstOrDefault();

                if (employee == null)
                {
                    result.ResultType = MessageType.NotFound;
                    result.Message = "No se encontró el empleado activo para calcular el pago.";
                    return result;
                }

                if (employee.CalculatedPayment == 0 && employee.EmployeeTypeId > 4)
                {
                    result.ResultType = MessageType.Error;
                    result.Message = "El tipo de empleado no cuenta con un esquema de pago válido.";
                    return result;
                }

                var payrollDto = new PayrollResultDto
                {
                    EmployeeId = employee.EmployeeId,
                    FullName = $"{employee.FirstName} {employee.LastName}",
                    EmployeeTypeId = employee.EmployeeTypeId,
                    WeeklyPayment = employee.CalculatedPayment
                };

                result.Data = payrollDto;
                result.Message = "Pago semanal calculado correctamente.";
            }
            catch (Exception ex)
            {
                result.ResultType = MessageType.Error;
                result.Message = "Error automático calculando el pago del empleado.";
                this._logger.LogError($"Ha ocurrido un error en el motor de nómina para el empleado {employeeId}: {ex.Message}.");
            }

            return result;
        }

    }
}