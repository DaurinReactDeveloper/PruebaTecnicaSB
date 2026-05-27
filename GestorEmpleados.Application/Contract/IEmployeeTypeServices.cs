using GestorEmpleados.Application.Core;
using GestorEmpleados.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Contract
{
    public interface IEmployeeTypeServices
    {
        Task<ServiceResult> GetEmployeeTypes();
    }
}
