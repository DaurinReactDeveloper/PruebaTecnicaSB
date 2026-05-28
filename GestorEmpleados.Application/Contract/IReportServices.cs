using GestorEmpleados.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Contract
{
    public interface IReportServices
    {
        Task<ServiceResult> GenerateWeeklyPayrollReport();
        Task<ServiceResult> CalculateWeeklyPayroll(int employeeId);

    }
}
