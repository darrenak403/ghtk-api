using Ghtk.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ghtk.Api.Controllers
{
    [Route("/services/shipment/")]
    [ApiController]
    public class ShipmentServiceController : ControllerBase
    {
        public ShipmentServiceController()
        {
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrder shipment)
        {
            return Ok();
        }
    }
}
