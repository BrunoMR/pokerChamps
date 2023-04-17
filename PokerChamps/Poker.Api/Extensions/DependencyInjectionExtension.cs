using Poker.Domain.Entities.Base;
using Poker.Infrastructure.Repositories;
using Poker.Infrastructure.Repositories.MongoDB.Context;

namespace Poker.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            // Repositories
            services.AddSingleton<IMongoContext, MongoContext>();
            services.AddScoped<IRepository<Entity>, AbstractRepository<Entity>>();


            // Handlers
            //services.AddTransient<IGetAllBoardsHandler, GetAllBoardsHandler>();

            //filter
            //services.AddScoped<UserAuthorizationAttribute>();

            // Adapters
            //services.AddScoped<IInventoryAdapter, InventoryAdapter>();

            return services;
        }
    }
}