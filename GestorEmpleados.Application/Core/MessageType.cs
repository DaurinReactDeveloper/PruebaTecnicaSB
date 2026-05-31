using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Core
{
    public enum MessageType
    {
        DefaultReturn = 0,
        Success = 1,
        Warning = 2,
        Error = 3,
        Unauthorized = 4,
        NotFound = 5 
    }

}
