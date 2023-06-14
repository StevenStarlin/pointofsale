using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseOrderItemController : Controller, IController<PurchaseOrderItem>
    {
        private readonly ILogger<PurchaseOrderItem> _logger;
        private readonly ControllerBase<PurchaseOrderItem> baseController;

        public PurchaseOrderItemController(ILogger<PurchaseOrderItem> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<PurchaseOrderItem>(logger);
        }

        [HttpDelete]
        public bool Delete(PurchaseOrderItem record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<PurchaseOrderItem> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public PurchaseOrderItem Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new PurchaseOrderItem();
        }

        [HttpPost]
        public PurchaseOrderItem Post(PurchaseOrderItem record)
        {
            return this.baseController.Post(record) ?? new PurchaseOrderItem();
        }
    }
}
