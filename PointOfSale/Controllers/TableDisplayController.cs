using Microsoft.AspNetCore.Mvc;

using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableDisplayController : Controller, IController<TableDisplay>
    {
        private readonly ILogger<TableDisplay> _logger;
        private readonly ControllerBase<TableDisplay> baseController;

        public TableDisplayController(ILogger<TableDisplay> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<TableDisplay>(logger);
        }

        [HttpDelete]
        public bool Delete(TableDisplay record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<TableDisplay> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public TableDisplay Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new TableDisplay();
        }

        [HttpPost]
        public TableDisplay Post(TableDisplay record)
        {
            return this.baseController.Post(record) ?? new TableDisplay();
        }
    }
}
