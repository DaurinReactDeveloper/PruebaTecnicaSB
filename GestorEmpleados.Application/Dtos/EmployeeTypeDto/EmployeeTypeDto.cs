using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Dtos.EmployeeTypeDto
{
    public class EmployeeTypeDto : DtoBase
    {
        public int EmployeeTypeId { get; set; }

        public string TypeName { get; set; }

    }
}
