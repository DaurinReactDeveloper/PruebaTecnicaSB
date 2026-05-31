using GestorEmpleados.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Validations
{
    public static class EmployeeTypeValidations
    {

        public static bool IsNullEmployeeType(List<EmployeeTypeModel> employeeType)
        {
            return employeeType is null;
        }

    }
}
