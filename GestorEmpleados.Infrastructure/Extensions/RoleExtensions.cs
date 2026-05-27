using GestorEmpleados.Domain.Entities;
using GestorEmpleados.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Infrastructure.Extensions
{
    public static class RoleExtensions
    {

        public static RoleModel RoleEntityToModel (this Role roleEntity)
        {
            return new RoleModel
            {
                RoleId = roleEntity.RoleId,
                RoleName = roleEntity.RoleName,
                Description = roleEntity.Description
            };
        }


    }
}
