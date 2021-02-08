using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rabbit.Consumer
{
    public class RabbitMQService : IRabbitMQService
    {
        


        public void RabbitConsumerRun()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var queueRoute = "test_queue";
                var exchangeName = "test_broker";
                channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
                channel.QueueDeclare(queue: queueRoute, durable: true, exclusive: false, autoDelete: false, arguments: null);
                channel.QueueBind(queueRoute, exchangeName, "ItemCreatedIntegrationEvent", null);


                Console.WriteLine(" [*] Waiting for messages.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: queueRoute, autoAck: true, consumer: consumer);


                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();


            }
        }
    }
}
