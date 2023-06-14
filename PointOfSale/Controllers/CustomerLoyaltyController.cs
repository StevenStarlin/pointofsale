using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerLoyaltyController : Controller, IController<CustomerLoyalty>
    {
        private readonly ILogger<CustomerLoyalty> _logger;
        private readonly ControllerBase<CustomerLoyalty> baseController;

        public CustomerLoyaltyController(ILogger<CustomerLoyalty> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<CustomerLoyalty>(logger);
        }

        [HttpDelete]
        public bool Delete(CustomerLoyalty record)
        {
            this._logger.LogInformation($"Attempting to delete {typeof(CustomerLoyalty)} with id {record.Id}");

            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<CustomerLoyalty> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public CustomerLoyalty Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new CustomerLoyalty();
        }

        [HttpPost]
        public CustomerLoyalty Post(CustomerLoyalty record)
        {
            return this.baseController.Post(record) ?? new CustomerLoyalty();
        }
    }
}
