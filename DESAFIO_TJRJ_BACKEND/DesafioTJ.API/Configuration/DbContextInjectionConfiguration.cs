using DesafioTJ.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace DesafioTJ.API.Configuration
{
    public static class DbContextInjectionConfiguration
    {
        public static IServiceCollection AddDbContextInjectionConfiguration(this IServiceCollection services, string connectionString) 
        {
            if (connectionString is not null)
            {
                services.AddDbContext<UsuarioContext>(option =>
                {
                    option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                }); 
            }

            return services;
        }
    }
}
