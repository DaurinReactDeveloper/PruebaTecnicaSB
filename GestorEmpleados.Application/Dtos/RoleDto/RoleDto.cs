using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Dtos.RoleDto
{
    public class RoleDto : DtoBase
    {

        public int RoleId { get; set; }

        public string RoleName { get; set; }

    }
}
