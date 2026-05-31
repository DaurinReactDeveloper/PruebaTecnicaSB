using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Infrastructure.Models
{
    public class EmployeeTypeModel
    {
        public int EmployeeTypeId { get; set; }

        public string TypeName { get; set; }

        public string Description { get; set; }
    }
}
