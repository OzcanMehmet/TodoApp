using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Service
{
    public static class UseHangfire
    {
        internal static IServiceCollection HangfireConfig(this IServiceCollection services,string ConnectionString)
        {
            services.AddHangfire(_ =>
            {
                _.UseSqlServerStorage(ConnectionString);
            });
            return services; 
        }
    }
}
