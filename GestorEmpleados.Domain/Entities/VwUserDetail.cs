using System;
using System.Collections.Generic;


namespace GestorEmpleados.Domain.Entities
{
    public partial class VwUserDetail
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

