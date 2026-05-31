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
    public static class EmployeeStatusDependencies
    {
        public static void AddEmployeeStatusDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeStatus, EmployeeStatusRepository>();
            services.AddTransient<IEmployeeStatusServices, EmployeeStatusServices>();
        }
    }
}
