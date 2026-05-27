using GestorEmpleados.Domain.Entities;
using GestorEmpleados.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Infrastructure.Extensions
{
    public static class EmployeeStatusExtensions
    {

        public static EmployeeStatusModel EmployeeStatusEntityToModel(this EmployeeStatus employeeStatusEntity)
        {
            return new EmployeeStatusModel
            {
                EmployeeStatusId = employeeStatusEntity.EmployeeStatusId,
                StatusName = employeeStatusEntity.StatusName,
                Description = employeeStatusEntity.Description
            };
        }


    }
}
