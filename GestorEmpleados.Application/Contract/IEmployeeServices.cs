using GestorEmpleados.Application.Core;
using GestorEmpleados.Application.Dtos.EmployeeDto;
using GestorEmpleados.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Contract
{
    public interface IEmployeeServices : IBaseServices<EmployeeAddDto, EmployeeUpdateDto, EmployeeRemoveDto>
    {

        Task<ServiceResult> GetEmployees();
        Task<ServiceResult> GetEmployeeById(int id);
        Task<ServiceResult> GetEmployeeBySSN(string SocialSecurityNumber);
        Task<ServiceResult> GetEmployeeByFilter(string name, int? departmentId, int? employeeStatusId);

    }
}
