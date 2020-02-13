using System;
using System.Threading.Tasks;
using FireOnWheels.Messaging;
using MassTransit;

namespace FireOnWheels.Registration.Service
{
    public class OrderReceivedConsumer: IConsumer<IOrderReceivedEvent>
    {
        public async Task Consume(ConsumeContext<IOrderReceivedEvent> context)
        {
            //Store order registration and get Id
            var id = 12;

            await Console.Out.WriteLineAsync($"Order with id {id} registered");

            //publish event
            await context.Publish<IOrderRegisteredEvent>(
                new {CorrelationId = context.Message.CorrelationId});
        }
    }
}
