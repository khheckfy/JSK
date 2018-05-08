using AutoMapper;
using JSK.BusinessLayer.Interfaces;
using JSK.BusinessLayer.Services;
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
            services.AddTransient<ITestService, TestService>();
            services.AddTransient<IUserService, UserService>();

            services.AddAutoMapper();
            Mappings.RegisterMappings();
            return services;
        }
    }
}
