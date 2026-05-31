using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Infrastructure.Exceptions
{
    public class EmployeeExceptions : Exception
    {

        public EmployeeExceptions(string message) : base(message)
        {

        }

    }
}
