using ATM.Repository;
using ATM.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ATM.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IOperationService, OperationService>();
        }
    }
}
