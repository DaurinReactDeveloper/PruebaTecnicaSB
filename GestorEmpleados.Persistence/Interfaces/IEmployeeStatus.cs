using GestorEmpleados.Domain.Entities;
using GestorEmpleados.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Persistence.Interfaces
{
    public interface IEmployeeStatus : IBaseRepository<EmployeeStatus>
    {
        Task<List<EmployeeStatus>> GetEmployeeStatuses();
    }
}
