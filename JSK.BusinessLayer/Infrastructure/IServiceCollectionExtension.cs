using JSK.Data.EntityFramework;
using JSK.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace JSK.BusinessLayer.Infrastructure
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddBusinessLayerDataFramework(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUnitOfWork>(s => new UnitOfWork(connectionString));
            return services;
        }
    }
}
