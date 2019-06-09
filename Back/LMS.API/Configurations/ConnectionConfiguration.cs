using LMS.CORE.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.API.Configurations
{
    public static class ConnectionConfiguration
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<LMSContext>(opt =>
                opt.UseSqlServer(conf.GetConnectionString("LMS"), b => b.MigrationsAssembly("LMS.API"))
               // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
               );

            return services;
        }
    }
}
