using Common.Methods;
using Common.Methods.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ObjectPool;
using RabbitMQ.Client;
using System;

namespace Common.RabbitMq
{
    public static class RabbitServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbit(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitConfig = configuration.GetSection("RabbitConfiguration");
            services.Configure<RabbitMqConfiguration>(rabbitConfig);

            services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
            services.AddSingleton<IPooledObjectPolicy<IModel>, RabbitModelPooledObjectPolicy>();

            return services;
        }
    }
}
