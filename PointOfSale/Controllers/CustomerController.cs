using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller, IController<Customer>
    {
        private readonly ILogger<Customer> _logger;
        private readonly ControllerBase<Customer> baseController;

        public CustomerController(ILogger<Customer> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<Customer>(logger);
        }

        [HttpDelete]
        public bool Delete(Customer record)
        {
            return baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<Customer> Get(int? recordsPerPage, int? pageNumber)
        {
            return baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public Customer Get(int recordID)
        {
            return baseController.Get(recordID) ?? new Customer();
        }

        [HttpPost]
        public Customer Post(Customer record)
        {
            return baseController.Post(record) ?? new Customer();
        }
    }
}
