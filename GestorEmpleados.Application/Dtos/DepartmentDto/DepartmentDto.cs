using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Dtos.DepartmentDto
{
    public class DepartmentDto : DtoBase
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

    }
}
