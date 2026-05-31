using GestorEmpleados.Domain.Entities;
using GestorEmpleados.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Infrastructure.Extensions
{
    public static class UserExtensions
    {

        public static UserModel UserEntityToModel(this User userEntity)
        {
            return new UserModel
            {
                UserId = userEntity.UserId,
                Email = userEntity.Email,
                Username = userEntity.Username,
                PasswordHash = userEntity.PasswordHash,
                RoleId = userEntity.RoleId
            };
        }

        public static User UserModelToEntity(this UserModel userEntity)
        {
            return new User
            {
                UserId = userEntity.UserId,
                Email = userEntity.Email,
                Username = userEntity.Username,
                PasswordHash = userEntity.PasswordHash,
                RoleId = userEntity.RoleId
            };
        }

    }
}
