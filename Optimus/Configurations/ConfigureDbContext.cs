using Microsoft.EntityFrameworkCore;
using Optimus.Data;
using System.Runtime.CompilerServices;

namespace Optimus.Configurations
{
    public static class ConfigureDbContext
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection serviceCollection, IConfiguration configuration) 
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(
                op=> {
                    op.UseSqlServer(configuration["ConnectionStrings:SqlServer"]);
                });

            
            return serviceCollection;
        }

    }
}
