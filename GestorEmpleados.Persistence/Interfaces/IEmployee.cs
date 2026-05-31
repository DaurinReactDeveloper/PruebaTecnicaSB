using GestorEmpleados.Domain.Entities;
using GestorEmpleados.Domain.Repository;
using GestorEmpleados.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Persistence.Interfaces
{
    public interface IEmployee : IBaseRepository<Employee>
    {
        Task<List<Vw_EmployeModel>> GetEmployees();
        Task<EmployeeModel> GetEmployeeById(int id);
        Task<EmployeeModel> GetEmployeeBySSN(string SocialSecurityNumber);
        Task<List<EmployeeModel>> GetEmployeeByFilter(string name, int? departmentId, int? employeeStatusId);
        Task<List<PayrollEmployeeModel>> GetPayroll(int? employeeId, DateTime startDate, DateTime endDate);
    }
}
