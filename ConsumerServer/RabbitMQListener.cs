using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ConsumerServer
{
    public static class RabbitMQListener
    {
        private static IConnection connection;
        private static IModel channel;

        public static void Start(string name="job", string queue="hello") {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(
                    queue: queue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                
                var receivedTime = DateTime.Now.ToString("yyyyMMddHHmmss"); // case sensitive


                Console.WriteLine($"[{name}] [{receivedTime}] Received {message}");
                Thread.Sleep(100);

                Console.WriteLine(" [x] Done");
                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

                //ServiceRegistryController src = new ServiceRegistryController();
                //src.PostAsync(message);
            };

            channel.BasicConsume(
                queue: queue,
                autoAck: false,
                consumer: consumer);
        }

        public static void Stop() {
            channel.Close(500, "Channel closed");
            connection.Close();
        }
    }
}