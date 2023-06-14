using Microsoft.AspNetCore.Mvc;

using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableController : Controller, IController<Table>
    {
        private readonly ILogger<Table> _logger;
        private readonly ControllerBase<Table> baseController;

        public TableController(ILogger<Table> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<Table>(logger);
        }

        [HttpDelete]
        public bool Delete(Table record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<Table> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public Table Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new Table();
        }

        [HttpPost]
        public Table Post(Table record)
        {
            return this.baseController.Post(record) ?? new Table();
        }
    }
}
