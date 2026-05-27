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
        Task<List<EmployeeModel>> GetEmployees();
        Task<EmployeeModel> GetEmployeeById(int id);
        Task<List<EmployeeModel>> GetEmployeeByFilter(string name, int? departmentId, int? employeeStatusId);

    }
}
