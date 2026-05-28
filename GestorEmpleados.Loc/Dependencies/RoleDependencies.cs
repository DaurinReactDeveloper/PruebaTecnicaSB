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
    public static class RoleDependencies
    {
        public static void AddRolDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRole, RoleRepository>();
            services.AddTransient<IRoleServices, RoleServices>();
        }
    }
}
