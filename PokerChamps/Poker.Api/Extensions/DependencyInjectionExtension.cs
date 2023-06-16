using Poker.Domain.Adapters.Repositories;
using Poker.Domain.Entities.Base;
using Poker.Domain.Entities.Config;
using Poker.Domain.Services.Config.Interfaces;
using Poker.Domain.Services.Shared;
using Poker.Domain.Services.Shared.Interfaces;
using Poker.Infrastructure.Repositories;
using Poker.Infrastructure.Repositories.MongoDB.Context;

namespace Poker.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IRepository<Entity>, AbstractRepository<Entity>>();
            services.AddScoped<IRepository<Configs>, AbstractRepository<Configs>>();


            // Services
            services.AddScoped<ICreateService<Entity>, CreateService<Entity>>();
            services.AddScoped<ICreateService<Configs>, CreateService<Configs>>();
            //services.AddTransient<IGetAllBoardsHandler, GetAllBoardsHandler>();

            //filter
            //services.AddScoped<UserAuthorizationAttribute>();

            // Adapters
            //services.AddScoped<IInventoryAdapter, InventoryAdapter>();

            return services;
        }
    }
}