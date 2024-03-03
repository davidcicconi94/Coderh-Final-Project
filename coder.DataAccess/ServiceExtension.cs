using coder.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder.DataAccess
{
    public static class ServiceExtension
    {
        public static IServiceCollection addPersistance(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("CoderDb");

            services.AddDbContext<CoderDbContext>(options => options.UseSqlServer(connectionString));   

            return services;
        }
    }
}
