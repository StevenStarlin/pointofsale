using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscountController : Controller, IController<Discount>
    {
        private readonly ILogger<Discount> _logger;
        private readonly ControllerBase<Discount> baseController;

        public DiscountController(ILogger<Discount> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<Discount>(logger);
        }

        [HttpDelete]
        public bool Delete(Discount record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<Discount> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public Discount Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new Discount();
        }

        [HttpPost]
        public Discount Post(Discount record)
        {
            return this.baseController.Post(record) ?? new Discount();
        }
    }
}
