using GestorEmpleados.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Validations
{
    public static class RolValidations
    {

        public static bool IsValidRoleId(int id)
        {
            return id > 0;
        }

        public static bool IsNullRole(RoleModel role)
        {
            return role is null;
        }

        public static bool IsNullRoles(List<RoleModel> role)
        {
            return role is null;
        }


    }
}
