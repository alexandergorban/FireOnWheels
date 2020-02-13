using System;
using System.Threading.Tasks;
using FireOnWheels.Messaging;
using MassTransit;

namespace FireOnWheels.Finance.Service
{
    public class OrderRegisteredConsumer: IConsumer<IOrderRegisteredEvent>
    {
        public async Task Consume(ConsumeContext<IOrderRegisteredEvent> context)
        {
            //Save to db
            await Console.Out.WriteLineAsync($"New order received: Order id {context.Message.OrderId}");
        }
    }
}
