using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitOfMeasureController : Controller, IController<UnitOfMeasure>
    {
        private readonly ILogger<UnitOfMeasure> _logger;
        private readonly ControllerBase<UnitOfMeasure> baseController;

        public UnitOfMeasureController(ILogger<UnitOfMeasure> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<UnitOfMeasure>(logger);
        }

        [HttpDelete]
        public bool Delete(UnitOfMeasure record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<UnitOfMeasure> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public UnitOfMeasure Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new UnitOfMeasure();
        }

        [HttpPost]
        public UnitOfMeasure Post(UnitOfMeasure record)
        {
            return this.baseController.Post(record) ?? new UnitOfMeasure();
        }
    }
}
