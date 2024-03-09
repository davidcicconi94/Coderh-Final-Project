using coder.Application.Infrastructure;
using coder.Application.Infrastructure.Mapping;
using coder.DataAccess.Data;
using coder.DataAccess.Persistance;
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
        public static IServiceCollection AddGenericRepository(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("CoderDb");

            services.AddDbContext<CoderDbContext>(options => options.UseSqlServer(connectionString));   

            return services;
        }

        public static IServiceCollection AddAutoMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfig));

            return services;
        }

        public static IServiceCollection AddMediatRService(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(Application.Application).Assembly);
            });

            return services;
        }
    }
}
