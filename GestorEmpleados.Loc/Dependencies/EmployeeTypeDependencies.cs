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
    public static class EmployeeTypeDependencies
    {
        public static void AddEmployeeTypeDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeType, EmployeeTypeRepository>();
            services.AddTransient<IEmployeeTypeServices, EmployeeTypeServices>();
        }
    }
}
