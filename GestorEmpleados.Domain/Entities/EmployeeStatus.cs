using GestorEmpleados.Domain.Core;
using System;
using System.Collections.Generic;

namespace GestorEmpleados.Domain.Entities
{

    public partial class EmployeeStatus : BaseEntity
    {
        public int EmployeeStatusId { get; set; }

        public string StatusName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}