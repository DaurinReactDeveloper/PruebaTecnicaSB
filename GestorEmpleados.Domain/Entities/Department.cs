using GestorEmpleados.Domain.Core;
using System;
using System.Collections.Generic;

namespace GestorEmpleados.Domain.Entities
{

    public partial class Department : BaseEntity
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}