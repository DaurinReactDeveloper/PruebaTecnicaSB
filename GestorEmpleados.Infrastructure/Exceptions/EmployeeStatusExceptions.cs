using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Infrastructure.Exceptions
{
    public class EmployeeStatusExceptions : Exception
    {

        public EmployeeStatusExceptions(string message) : base(message)
        {

        }


    }
}
