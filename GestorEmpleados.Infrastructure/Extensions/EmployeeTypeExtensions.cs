using GestorEmpleados.Domain.Entities;
using GestorEmpleados.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Infrastructure.Extensions
{
    public static class EmployeeTypeExtensions
    {

        public static EmployeeTypeModel EmployeeTypeEntityToModel(this EmployeeType employeeTypeEntity)
        {
            return new EmployeeTypeModel
            {
                EmployeeTypeId = employeeTypeEntity.EmployeeTypeId,
                TypeName = employeeTypeEntity.TypeName,
                Description = employeeTypeEntity.Description
            };
        }


    }
}
