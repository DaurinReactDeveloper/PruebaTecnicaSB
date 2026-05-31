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
    public static class ReportDependencies
    {

        public static void AddReportDependencies(this IServiceCollection services)
        {
            services.AddScoped<IReportServices, ReportServices>();
        }

    }
}
