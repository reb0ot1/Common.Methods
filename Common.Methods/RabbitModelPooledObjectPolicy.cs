using Common.Methods.Configurations;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Methods
{
    public class RabbitModelPooledObjectPolicy : IPooledObjectPolicy<IModel>
    {
        private readonly RabbitMqConfiguration _options;

        public RabbitModelPooledObjectPolicy(IOptions<RabbitMqConfiguration> rabbitConf)
        {
            this._options = rabbitConf.Value;
            this.Connection = this.GetConnection();
        }

        public IConnection Connection { get; private set; }

        private IConnection GetConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = _options.HostName,
                UserName = _options.UserName,
                Password = _options.Password,
                Port = _options.Port,
                VirtualHost = _options.VHost
            };

            return factory.CreateConnection();
        }

        public IModel Create()
        {
            return this.Connection.CreateModel();
        }

        public bool Return(IModel obj)
        {
            if (obj.IsOpen)
            {
                return true;
            }
            else
            {
                obj?.Dispose();
                return false;
            }
        }
    }
}
