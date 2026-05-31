using System;
using System.Collections.Generic;


namespace GestorEmpleados.Domain.Entities
{

    public partial class VwEmployeeDetail
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string SocialSecurityNumber { get; set; }

        public int EmployeeTypeId { get; set; }

        public string EmployeeTypeName { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public int EmployeeStatusId { get; set; }

        public string StatusName { get; set; }

        public decimal? WeeklySalary { get; set; }

        public decimal? HourlyRate { get; set; }

        public decimal? HoursWorked { get; set; }

        public decimal? GrossSales { get; set; }

        public decimal? CommissionRate { get; set; }

        public decimal? BaseSalary { get; set; }

        public bool Deleted { get; set; }

        public string? ModifiedBy { get; set; }


    }
}