using GestorEmpleados.Application.Core;
using GestorEmpleados.Application.Dtos.PayrollResultDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Contract
{
    public interface IReportServices
    {
        Task<ServiceResult> GenerateWeeklyPayrollReport(PayrollReportRequestDto request);
        Task<ServiceResult> CalculateWeeklyPayroll(int employeeId, PayrollReportRequestDto request);

    }
}
