using System;
using FireOnWheels.Messaging;
using MassTransit;

namespace FireOnWheels.Notification.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Notification";

            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, RabbitMqConstants.NotificationServiceQueue, e =>
                {
                    e.Consumer<OrderRegisteredConsumer>();
                });
            });

            bus.Start();

            Console.WriteLine("Listening for Order registered events.. Press enter to exit");
            Console.ReadLine();

            bus.Stop();
        }
    }
}
