using GestorEmpleados.Domain.Entities;
using GestorEmpleados.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Infrastructure.Extensions
{
    public static class EmployeeExtensions
    {

        public static EmployeeModel EmployeeEntityToModel(this Employee employeeEntity)
        {
            return new EmployeeModel
            {
                EmployeeId = employeeEntity.EmployeeId,
                FirstName = employeeEntity.FirstName,
                LastName = employeeEntity.LastName,
                SocialSecurityNumber = employeeEntity.SocialSecurityNumber,
                EmployeeTypeId = employeeEntity.EmployeeTypeId,
                DepartmentId = employeeEntity.DepartmentId,
                EmployeeStatusId = employeeEntity.EmployeeStatusId,
                WeeklySalary = employeeEntity.WeeklySalary,
                HourlyRate = employeeEntity.HourlyRate,
                HoursWorked = employeeEntity.HoursWorked,
                GrossSales = employeeEntity.GrossSales,
                CommissionRate = employeeEntity.CommissionRate,
                BaseSalary = employeeEntity.BaseSalary
            };
        }


        public static Employee EmployeeModelToEntity(this EmployeeModel employeeEntity)
        {
            return new Employee
            {
                EmployeeId = employeeEntity.EmployeeId,
                FirstName = employeeEntity.FirstName,
                LastName = employeeEntity.LastName,
                SocialSecurityNumber = employeeEntity.SocialSecurityNumber,
                DepartmentId = employeeEntity.DepartmentId,
                EmployeeStatusId = employeeEntity.EmployeeStatusId,
                WeeklySalary = employeeEntity.WeeklySalary,
                HourlyRate = employeeEntity.HourlyRate,
                HoursWorked = employeeEntity.HoursWorked,
                GrossSales = employeeEntity.GrossSales,
                CommissionRate = employeeEntity.CommissionRate,
                BaseSalary = employeeEntity.BaseSalary
            };
        }

    }
}
