using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Consumer
{
    public class Program
    {

        //https://github.com/choudhurynirjhar/rabbitmq-demo/blob/master/RabbitMQ.Producer/DirectExchangePublisher.cs
        //static async Task Main(string[] args)
        //{
        //CreateHostBuilder(args).Build().RunAsync();
        //using IHost host = CreateHostBuilder(args).Build();


        // Application code should start here.

        //var rabbitConsumer = ActivatorUtilities.CreateInstance<RabbitMQService>(host.Services);
        //rabbitConsumer.RabbitConsumerRun();

        //await host.RunAsync();



        //var host = Host.CreateDefaultBuilder()
        //    .ConfigureServices((context, services) =>
        //    {
        //        services.AddTransient<IRabbitMQService, RabbitMQService>();
        //    })
        //    .Build();

        //var rabbitConsumer = ActivatorUtilities.CreateInstance<RabbitMQService>(host.Services);
        //rabbitConsumer.RabbitConsumerRun();

        //}
        private readonly static DependencyContainer _dependencyContainer = new DependencyContainer();
        public Program()
        {
            //_dependencyContainer = new DependencyContainer();
        }
        static Task Main(string[] args)
        {
            
            return CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IConsumerMassTransitConfig, ConsumerMassTransitConfig>();
                    services.AddTransient<IRabbitMQService, RabbitMQService>();
                    services.AddHostedService<HostServices>();
                    //_dependencyContainer.RegisterServices(services, hostContext);
                });
                //.ConfigureServices((_, services) =>
                //    services.AddHostedService<HostServices>())
                //.ConfigureServices((context, services) =>
                //    {
                //        services.AddTransient<IRabbitMQService, RabbitMQService>();
                //        services.AddTransient<IConsumerMassTransitConfig, ConsumerMassTransitConfig>();
                //        services.AddMassTransit(config =>
                //        {
                //            config.AddConsumer<OrderConsumer>();
                //            config.UsingRabbitMq((ctx, cfg) =>
                //            {
                //                cfg.Host("amqp://guest:guest@localhost:5672");
                //                cfg.ReceiveEndpoint("order-queue", c => { c.ConfigureConsumer<OrderConsumer>(ctx); });
                //            });
                //        });
                //        services.AddMassTransitHostedService();
                //    });

            //static IHostBuilder CreateHostBuilder(string[] args) =>
            //    Host.CreateDefaultBuilder(args)
            //        .ConfigureHostConfiguration(configHost =>
            //        {
            //            configHost.SetBasePath(Directory.GetCurrentDirectory());
            //            configHost.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //            configHost.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true);
            //            configHost.AddEnvironmentVariables();
            //            configHost.AddCommandLine(args);
            //        }).ConfigureServices((context, services) => 
            //        {
            //            services.AddTransient<IRabbitMQService, RabbitMQService>();
            //            //services.AddHostedService<RabbitMQService>();
            //        });

            //static IHostBuilder CreateHostBuilder(string[] args) =>
            //   Host.CreateDefaultBuilder(args)
            //       .ConfigureHostConfiguration(configHost =>
            //       {
            //           configHost.SetBasePath(Directory.GetCurrentDirectory());
            //           configHost.AddJsonFile("appsettings.json", optional: true);
            //           configHost.AddEnvironmentVariables(prefix: "PREFIX_");
            //           configHost.AddCommandLine(args);
            //       });

            //static void BuildConfig(IConfigurationBuilder builder)
            //{
            //    builder.SetBasePath(Directory.GetCurrentDirectory())
            //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            //        .AddEnvironmentVariables();
            //}


            //var rabbitRoute = "RabbitQueue";
            //var factory = new ConnectionFactory
            //{
            //    Uri = new Uri("amqp://guest:guest@localhost:5672")
            //};
            //using var connection = factory.CreateConnection();
            //using var channel = connection.CreateModel();
            //channel.QueueDeclare(
            //    queue: rabbitRoute,
            //    durable: true,
            //    exclusive: false,
            //    autoDelete: false,
            //    arguments: null);
            //var consumer = new EventingBasicConsumer(channel);
            //consumer.Received += (sender, e) =>
            //{
            //    var body = e.Body.ToArray();
            //    var message = Encoding.UTF8.GetString(body);
            //    Console.WriteLine(message);
            //};
            //channel.BasicConsume(rabbitRoute, true, consumer);
            //Console.WriteLine("RabbitMQ Consumer Start Listening...!");
            //Console.ReadLine();
            //--====================================================================================

            //var factory = new ConnectionFactory() { HostName = "localhost" };
            //using (var connection = factory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
            //    var rabbitRoute = "rabbitRouteKey";
            //    channel.QueueDeclare(queue: rabbitRoute, durable: false, exclusive: false, autoDelete: false, arguments: null);

            //    Console.WriteLine(" [*] Waiting for messages.");

            //    var consumer = new EventingBasicConsumer(channel);
            //    consumer.Received += (model, ea) =>
            //    {
            //        var body = ea.Body.ToArray();
            //        var message = Encoding.UTF8.GetString(body);
            //        Console.WriteLine(" [x] Received {0}", message);
            //    };
            //    channel.BasicConsume(queue: rabbitRoute, autoAck: true, consumer: consumer);

            //    Console.WriteLine(" Press [enter] to exit.");
            //    Console.ReadLine();
            //}

            //============================================================================================

            //var factory = new ConnectionFactory() { HostName = "localhost" };
            //using (var connection = factory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
            //    var queueRoute = "rabbitRouteKey";
            //    var exchangeName = "RabbitExchanges";
            //    channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            //    channel.QueueDeclare(queue: queueRoute, durable: false, exclusive: false, autoDelete: false, arguments: null);
            //    channel.QueueBind(queueRoute, exchangeName, queueRoute, null);


            //    Console.WriteLine(" [*] Waiting for messages.");

            //    var consumer = new EventingBasicConsumer(channel);
            //    consumer.Received += (model, ea) =>
            //    {
            //        var body = ea.Body.ToArray();
            //        var message = Encoding.UTF8.GetString(body);
            //        Console.WriteLine(" [x] Received {0}", message);
            //    };
            //    channel.BasicConsume(queue: queueRoute, autoAck: true, consumer: consumer);


            //    Console.WriteLine(" Press [enter] to exit.");
            //    Console.ReadLine();


            //}
    }
}
