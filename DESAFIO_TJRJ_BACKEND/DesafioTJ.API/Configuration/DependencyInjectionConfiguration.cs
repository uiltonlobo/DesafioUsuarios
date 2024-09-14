using DesafioTJ.Domain.Interfaces.Repository;
using DesafioTJ.Domain.Interfaces.Service;
using DesafioTJ.Domain.Service;
using DesafioTJ.Infra.Database;
using DesafioTJ.Infra.Repository;

namespace DesafioTJ.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjections(this IServiceCollection services)
        {
            services.AddTransient<UsuarioContext>();

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<ITipoUsuarioRepository, TipoUsuarioRepository>();

            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<ITipoUsuarioService, TipoUsuarioService>();

            return services;
        }

    }
}
