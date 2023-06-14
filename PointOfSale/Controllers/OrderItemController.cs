using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;
using System.Data.Entity.Core.Mapping;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderItemController : Controller, IController<OrderItem>
    {
        private readonly ILogger<OrderItem> _logger;
        private readonly ControllerBase<OrderItem> baseController;

        public OrderItemController(ILogger<OrderItem> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<OrderItem>(logger);
        }

        [HttpDelete]
        public bool Delete(OrderItem record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<OrderItem> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public OrderItem Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new OrderItem();
        }

        [HttpPost]
        public OrderItem Post(OrderItem record)
        {
            return this.baseController.Post(record) ?? new OrderItem();
        }
    }
}
