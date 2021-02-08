using Microsoft.Extensions.Hosting;

namespace Rabbit.Consumer
{
    public interface IRabbitMQService 
    {
        void RabbitConsumerRun();
    }
}