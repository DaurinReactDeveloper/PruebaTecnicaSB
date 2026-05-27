using GestorEmpleados.Application.Dtos.DepartmentDto;
using GestorEmpleados.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Validations
{
    public static class DeparmentValidations
    {

        public static bool GetDepartmentValidation(List<DepartmentModel> departmentDto)
        {

            if(departmentDto is null)
            {
                return false;
            }

            return true;
        }


    }
}
