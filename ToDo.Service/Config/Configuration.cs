using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Data.Context;
using ToDo.Data.Interface;
using ToDo.Data.Repository;
using ToDo.Service.Interface;

namespace ToDo.Service.Config
{
    public  static class Configuration
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services,string HangfireConnectionString)
        {
            UseHangfire.HangfireConfig(services, HangfireConnectionString);
            services.AddSingleton<ITodoTaskManager, TodoTaskManager>();
            services.AddTransient<ITodoService, TodoService>();
            services.AddTransient<IToDoRepository, EntityTodoRepository>();
           
            return services;
        }
        public static IApplicationBuilder UseServiceConfigure(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard();
            app.UseHangfireServer();
            return app;
        }
    }
}
