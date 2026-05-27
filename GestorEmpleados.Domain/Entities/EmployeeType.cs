using GestorEmpleados.Domain.Core;
using System;
using System.Collections.Generic;

namespace GestorEmpleados.Domain.Entities
{
    public partial class EmployeeType : BaseEntity
    {
        public int EmployeeTypeId { get; set; }

        public string TypeName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}