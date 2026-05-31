using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Contract
{
    public interface IJwtServices
    {
        public string GenerateToken(string name, string role, string email);
    }
}
