using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Infrastructure.Models
{
    public class EmployeeStatusModel
    {
        public int EmployeeStatusId { get; set; }

        public string StatusName { get; set; }

        public string Description { get; set; }
    }
}
