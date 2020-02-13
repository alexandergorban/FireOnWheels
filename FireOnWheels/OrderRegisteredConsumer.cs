using System;
using System.Threading.Tasks;
using FireOnWheels.Messaging;
using MassTransit;

namespace FireOnWheels.Notification.Service
{
    public class OrderRegisteredConsumer: IConsumer<IOrderRegisteredEvent>
    {
        public async Task Consume(ConsumeContext<IOrderRegisteredEvent> context)
        {
            //Send notification to user
            await Console.Out.WriteLineAsync($"Customer notification sent: Order id {context.Message.CorrelationId}");
        }
    }
}
