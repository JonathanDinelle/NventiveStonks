using Microsoft.AspNetCore.Mvc;
using Stonks.Orders.Application.CommandHandlers;

namespace Stonks.Orders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public ActionResult PlaceOrder([FromBody] CreateOrderCommand command)
        {
            return Ok();
        }
    }
}
