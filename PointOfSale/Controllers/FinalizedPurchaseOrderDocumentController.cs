using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinalizedPurchaseOrderDocumentController : Controller, IController<FinalizedPurchaseOrderDocument>
    {
        private readonly ILogger<FinalizedPurchaseOrderDocument> _logger;
        private readonly ControllerBase<FinalizedPurchaseOrderDocument> baseController;

        public FinalizedPurchaseOrderDocumentController(ILogger<FinalizedPurchaseOrderDocument> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<FinalizedPurchaseOrderDocument>(logger);
        }

        [HttpDelete]
        public bool Delete(FinalizedPurchaseOrderDocument record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<FinalizedPurchaseOrderDocument> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public FinalizedPurchaseOrderDocument Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new FinalizedPurchaseOrderDocument();
        }

        [HttpPost]
        public FinalizedPurchaseOrderDocument Post(FinalizedPurchaseOrderDocument record)
        {
            return this.baseController.Post(record) ?? new FinalizedPurchaseOrderDocument();
        }
    }
}
