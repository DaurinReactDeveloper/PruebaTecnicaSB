using GestorEmpleados.Domain.Core;
using System;
using System.Collections.Generic;


namespace GestorEmpleados.Domain.Entities
{

    public partial class User : BaseEntity
    {
        public int UserId { get; set; }

        public int EmployeeId { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public int RoleId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Role Role { get; set; }
    }
}