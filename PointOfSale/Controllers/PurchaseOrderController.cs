using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseOrderController : Controller, IController<PurchaseOrder>
    {
        private readonly ILogger<PurchaseOrder> _logger;
        private readonly ControllerBase<PurchaseOrder> baseController;

        public PurchaseOrderController(ILogger<PurchaseOrder> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<PurchaseOrder>(logger);
        }

        [HttpDelete]
        public bool Delete(PurchaseOrder record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<PurchaseOrder> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public PurchaseOrder Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new PurchaseOrder();
        }

        [HttpPost]
        public PurchaseOrder Post(PurchaseOrder record)
        {
            return this.baseController.Post(record) ?? new PurchaseOrder();
        }
    }
}
