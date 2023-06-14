using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderStatusController : Controller, IController<OrderStatus>
    {
        private readonly ILogger<OrderStatus> _logger;
        private readonly ControllerBase<OrderStatus> baseController;

        public OrderStatusController(ILogger<OrderStatus> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<OrderStatus>(logger);
        }

        [HttpDelete]
        public bool Delete(OrderStatus record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<OrderStatus> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public OrderStatus Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new OrderStatus();
        }

        [HttpPost]
        public OrderStatus Post(OrderStatus record)
        {
            return this.baseController.Post(record) ?? new OrderStatus();
        }
    }
}
