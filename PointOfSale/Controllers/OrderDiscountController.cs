using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDiscountController : Controller, IController<OrderDiscount>
    {
        private readonly ILogger<OrderDiscount> _logger;
        private readonly ControllerBase<OrderDiscount> baseController;

        public OrderDiscountController(ILogger<OrderDiscount> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<OrderDiscount>(logger);
        }

        [HttpDelete]
        public bool Delete(OrderDiscount record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<OrderDiscount> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public OrderDiscount Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new OrderDiscount();
        }

        [HttpPost]
        public OrderDiscount Post(OrderDiscount record)
        {
            return this.baseController.Post(record) ?? new OrderDiscount();
        }
    }
}
