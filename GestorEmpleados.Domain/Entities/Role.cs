using GestorEmpleados.Domain.Core;
using System;
using System.Collections.Generic;

namespace GestorEmpleados.Domain.Entities
{
    public partial class Role : BaseEntity
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}