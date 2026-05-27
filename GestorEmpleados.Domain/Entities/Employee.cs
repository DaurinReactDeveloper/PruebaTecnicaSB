using GestorEmpleados.Domain.Core;
using System;
using System.Collections.Generic;

namespace GestorEmpleados.Domain.Entities
{
    public partial class Employee : BaseEntity
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SocialSecurityNumber { get; set; }

        public int EmployeeTypeId { get; set; }

        public int DepartmentId { get; set; }

        public int EmployeeStatusId { get; set; }

        public decimal? WeeklySalary { get; set; }

        public decimal? HourlyRate { get; set; }

        public decimal? HoursWorked { get; set; }

        public decimal? GrossSales { get; set; }

        public decimal? CommissionRate { get; set; }

        public decimal? BaseSalary { get; set; }

        public virtual Department Department { get; set; }

        public virtual EmployeeStatus EmployeeStatus { get; set; }

        public virtual EmployeeType EmployeeType { get; set; }

        public virtual User User { get; set; }
    }
}
