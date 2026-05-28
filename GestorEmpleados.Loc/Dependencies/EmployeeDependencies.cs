using GestorEmpleados.Application.Contract;
using GestorEmpleados.Application.Services;
using GestorEmpleados.Persistence.Interfaces;
using GestorEmpleados.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Loc.Dependencies
{
    public static class EmployeeDependencies
    {
        public static void AddEmployeeDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmployee, EmployeeRepository>();
            services.AddTransient<IEmployeeServices, EmployeeServices>();
        }
    }
}
