using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Infrastructure.Models
{
    public class Vw_UserDetailModel
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeFullName { get; set; }

        public int EmployeeStatusId { get; set; }

        public string PasswordHash { get; set; }

        public string SocialSecurityNumber { get; set; }

    }
}
