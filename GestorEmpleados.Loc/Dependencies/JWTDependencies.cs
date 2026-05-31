using GestorEmpleados.Application.Contract;
using GestorEmpleados.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Loc.Dependencies
{
    public static class JWTDependencies
    {
        public static void AddJWTDependencies(this IServiceCollection services)
        {
            services.AddScoped<IJwtServices, JwtServices>();
        }
    }
}
