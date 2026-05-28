using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Dtos.PayrollResultDto
{
    public class PayrollResultDto
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public int EmployeeTypeId { get; set; }
        public decimal WeeklyPayment { get; set; }

    }
}
