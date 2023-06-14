using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller, IController<Item>
    {
        private readonly ILogger<Item> _logger;
        private readonly ControllerBase<Item> baseController;

        public ItemController(ILogger<Item> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<Item>(logger);
        }

        [HttpDelete]
        public bool Delete(Item record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<Item> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public Item Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new Item();
        }

        [HttpPost]
        public Item Post(Item record)
        {
            return this.baseController.Post(record) ?? new Item();
        }
    }
}
