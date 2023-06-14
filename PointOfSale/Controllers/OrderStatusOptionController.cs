using Microsoft.AspNetCore.Mvc;

using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderStatusOptionController : Controller, IController<OrderStatusOption>
    {
        private readonly ILogger<OrderStatusOption> _logger;
        private readonly ControllerBase<OrderStatusOption> baseController;

        public OrderStatusOptionController(ILogger<OrderStatusOption> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<OrderStatusOption>(logger);
        }

        [HttpDelete]
        public bool Delete(OrderStatusOption record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<OrderStatusOption> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public OrderStatusOption Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new OrderStatusOption();
        }

        [HttpPost]
        public OrderStatusOption Post(OrderStatusOption record)
        {
            return this.baseController.Post(record) ?? new OrderStatusOption();
        }
    }
}
