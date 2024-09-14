namespace DesafioTJ.API.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperApi(this IServiceCollection services, Type assemblyContainingMappers)
        {
            services.AddAutoMapper(expression =>
            {
                expression.AllowNullCollections = true;
            }, assemblyContainingMappers);

            return services;
        }
    }
}
