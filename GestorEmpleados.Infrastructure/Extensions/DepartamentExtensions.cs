using GestorEmpleados.Domain.Entities;
using GestorEmpleados.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Infrastructure.Extensions
{
    public static class DepartamentExtensions 
    {

        public static DepartmentModel DeparmentEntityToModel (this Department departmentEntity)
        {
            return new DepartmentModel
            {
                DepartmentId = departmentEntity.DepartmentId,
                DepartmentName = departmentEntity.DepartmentName,
                Description = departmentEntity.Description
            };
        }

    }
}
