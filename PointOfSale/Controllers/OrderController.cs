using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller, IController<Order>
    {
        private readonly ILogger<Order> _logger;
        private readonly ControllerBase<Order> baseController;

        public OrderController(ILogger<Order> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<Order>(logger);
        }

        [HttpDelete]
        public bool Delete(Order record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<Order> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public Order Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new Order();
        }

        [HttpPost]
        public Order Post(Order record)
        {
            return this.baseController.Post(record) ?? new Order();
        }
    }
}
