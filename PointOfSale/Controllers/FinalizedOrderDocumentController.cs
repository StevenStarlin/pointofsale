using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinalizedOrderDocumentController : Controller, IController<FinalizedOrderDocument>
    {
        private readonly ILogger<FinalizedOrderDocument> _logger;
        private readonly ControllerBase<FinalizedOrderDocument> baseController;

        public FinalizedOrderDocumentController(ILogger<FinalizedOrderDocument> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<FinalizedOrderDocument>(logger);
        }

        [HttpDelete]
        public bool Delete(FinalizedOrderDocument record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<FinalizedOrderDocument> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public FinalizedOrderDocument Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new FinalizedOrderDocument();
        }

        [HttpPost]
        public FinalizedOrderDocument Post(FinalizedOrderDocument record)
        {
            return this.baseController.Post(record) ?? new FinalizedOrderDocument();
        }
    }
}
