using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Dtos.EmployeeStatusDto
{
    public class EmployeeStatusDto : DtoBase
    {

        public int EmployeeStatusId { get; set; }

        public string StatusName { get; set; }

    }
}
