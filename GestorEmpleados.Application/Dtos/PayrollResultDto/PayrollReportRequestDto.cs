using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Dtos.PayrollResultDto
{
    public class PayrollReportRequestDto
    {

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
