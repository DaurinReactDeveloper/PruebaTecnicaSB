using GestorEmpleados.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Validations
{
    public static class EmployeeStatusValidations
    {

        public static bool IsNullEmployeeStatus(List<EmployeeStatusModel> employeeStatuses)
        {
            return employeeStatuses == null || !employeeStatuses.Any();
        }

    }
}
