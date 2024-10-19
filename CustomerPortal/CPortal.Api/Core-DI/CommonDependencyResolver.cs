using LT.Infrastructure.UnitOfWork.Interfaces;
using LT.Infrastructure.UnitOfWork.Repositories;
using LT.Application.BusinessClasses;
using LT.Application.BusinessInterfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace LT.Api.Core_DI
{

    /// <summary>
    /// seperate static class to avoid loc in program.cs file
    /// Here we should only add dependencies for business classes
    /// Repositories classes are taken care by Unit Of Work
    /// </summary>
    public static class CommonDependencyResolver
    {
        public static IServiceCollection AddBALDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICorpService, CorpService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
        public static IServiceCollection AddDACDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IDistributedCache, MemoryDistributedCache>();
            return services;
        }

    }
}
