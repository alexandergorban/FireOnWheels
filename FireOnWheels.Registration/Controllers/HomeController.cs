using System;
using System.Threading.Tasks;
using FireOnWheels.Messaging;
using Microsoft.AspNet.Mvc;
using FireOnWheels.Registration.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FireOnWheels.Registration.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult RegisterOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterOrder(OrderViewModel model)
        {
            //Send RegisterOrderCommand
            var bus = BusConfigurator.ConfigureBus();

            var sendToUri = new Uri($"{RabbitMqConstants.RabbitMqUri}{RabbitMqConstants.SagaQueue}");
            var endPoint = await bus.GetSendEndpoint(sendToUri);

            await endPoint.Send<IRegisterOrderCommand>(new
            {
                PickupName = model.PickupName,
                PickupAddress = model.PickupAddress,
                PickupCity = model.PickupCity,
                DeliverName = model.DeliverName,
                DeliverAddress = model.DeliverAddress,
                DeliverCity = model.DeliverCity,
                Weight = model.Weight,
                Fragile = model.Fragile,
                Oversized = model.Oversized
            });

            return View("Thanks");
        }
    }
}
