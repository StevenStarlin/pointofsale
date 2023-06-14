using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    public class CustomerLoyaltyTransactionController : Controller, IController<CustomerLoyaltyTransaction>
    {
        private readonly ILogger<CustomerLoyaltyTransaction> _logger;
        private readonly ControllerBase<CustomerLoyaltyTransaction> baseController;

        public CustomerLoyaltyTransactionController(ILogger<CustomerLoyaltyTransaction> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<CustomerLoyaltyTransaction>(logger);
        }

        [HttpDelete]
        public bool Delete(CustomerLoyaltyTransaction record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<CustomerLoyaltyTransaction> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public CustomerLoyaltyTransaction Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new CustomerLoyaltyTransaction();
        }

        [HttpPost]
        public CustomerLoyaltyTransaction Post(CustomerLoyaltyTransaction record)
        {
            return this.baseController.Post(record) ?? new CustomerLoyaltyTransaction();
        }
    }
}
