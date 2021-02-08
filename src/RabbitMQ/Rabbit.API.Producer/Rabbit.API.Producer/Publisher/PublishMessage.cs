using Newtonsoft.Json;
using Rabbit.API.Producer.Controllers;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.API.Producer.Publisher
{
    public class PublishMessage
    {

        public void Message_Producer(Response publishData)
        {
            //var rabbitRoute = "RabbitQueue";
            //var factory = new ConnectionFactory
            //{
            //    Uri = new Uri("rabbitexchange://guest:guest@localhost:5672") //"amqp://guest:guest@localhost:5672"
            //};
            //using var connection = factory.CreateConnection();
            //using var channel = connection.CreateModel();
            //channel.QueueDeclare(
            //    queue: rabbitRoute,
            //    durable: true,
            //    exclusive: false,
            //    autoDelete: false,
            //    arguments: null);

            //var message = new { Name = publishData.Name, Message = publishData.Message };
            //var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            //channel.BasicPublish("", rabbitRoute, null, body);

            //=================================================================================================

            //var factory = new ConnectionFactory() { HostName = "localhost" };
            //using (var connection = factory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
            //    var rabbitRoute = "rabbitRouteKey";
            //    channel.QueueDeclare(queue: rabbitRoute, durable: false, exclusive: false, autoDelete: false, arguments: null);
            //    //Console.WriteLine("---->> " + message);
            //    string message = "Name: "+ publishData.Name + " Message: " + publishData.Message;
            //    var body = Encoding.UTF8.GetBytes(message);

            //    channel.BasicPublish(exchange: "", routingKey: rabbitRoute, basicProperties: null, body: body);
            //    Console.WriteLine(" [x] Sent {0}", message);
            //}

            //Console.WriteLine(" Press [enter] to exit.");

            //====================================================================================================

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var queueRoute = "rabbitRouteKey";
                var exchangeName = "RabbitExchanges";
                var routingKey = "";
                channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
                channel.QueueDeclare(queue: queueRoute, durable: false, exclusive: false, autoDelete: false, arguments: null);
                channel.QueueBind(queueRoute, exchangeName, routingKey, null);
                //Console.WriteLine("---->> " + message);
                string message = "Name: " + publishData.Name + " Message: " + publishData.Message;
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: queueRoute, basicProperties: null, body: body);
                //channel.BasicPublish(exchange: exchangeName, routingKey: routingKey, body: body, basicProperties: properties);

                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");

        }
    }
}
