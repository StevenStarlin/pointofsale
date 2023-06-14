using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemInventoryController : Controller, IController<ItemInventory>
    {
        private readonly ILogger<ItemInventory> _logger;
        private readonly ControllerBase<ItemInventory> baseController;

        public ItemInventoryController(ILogger<ItemInventory> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<ItemInventory>(logger);
        }

        [HttpDelete]
        public bool Delete(ItemInventory record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<ItemInventory> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public ItemInventory Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new ItemInventory();
        }

        [HttpPost]
        public ItemInventory Post(ItemInventory record)
        {
            return this.baseController.Post(record) ?? new ItemInventory();
        }
    }
}
