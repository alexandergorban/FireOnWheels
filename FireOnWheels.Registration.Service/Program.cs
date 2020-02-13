using System;
using FireOnWheels.Messaging;
using MassTransit;
using MassTransit.Courier;

namespace FireOnWheels.Registration.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Registration";

            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, RabbitMqConstants.RegisterOrderServiceQueue, e =>
                {
                    e.Consumer<OrderReceivedConsumer>();
                });
            });

            bus.Start();

            Console.WriteLine("Listening for Register order commands.. Press enter to exit");
            Console.ReadLine();

            bus.Stop();
        }
    }
}
