using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemRecipeController : Controller, IController<ItemRecipe>
    {
        private readonly ILogger<ItemRecipe> _logger;
        private readonly ControllerBase<ItemRecipe> baseController;

        public ItemRecipeController(ILogger<ItemRecipe> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<ItemRecipe>(logger);
        }

        [HttpDelete]
        public bool Delete(ItemRecipe record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<ItemRecipe> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public ItemRecipe Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new ItemRecipe();
        }

        [HttpPost]
        public ItemRecipe Post(ItemRecipe record)
        {
            return this.baseController.Post(record) ?? new ItemRecipe();
        }
    }
}
