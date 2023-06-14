using Microsoft.AspNetCore.Mvc;

using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendorTypeController : Controller, IController<VendorType>
    {
        private readonly ILogger<VendorType> _logger;
        private readonly ControllerBase<VendorType> baseController;

        public VendorTypeController(ILogger<VendorType> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<VendorType>(logger);
        }

        [HttpDelete]
        public bool Delete(VendorType record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<VendorType> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public VendorType Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new VendorType();
        }

        [HttpPost]
        public VendorType Post(VendorType record)
        {
            return this.baseController.Post(record) ?? new VendorType();
        }
    }
}
