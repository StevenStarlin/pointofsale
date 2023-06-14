using Microsoft.AspNetCore.Mvc;

using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendorController : Controller, IController<Vendor>
    {
        private readonly ILogger<Vendor> _logger;
        private readonly ControllerBase<Vendor> baseController;

        public VendorController(ILogger<Vendor> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<Vendor>(logger);
        }

        [HttpDelete]
        public bool Delete(Vendor record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<Vendor> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public Vendor Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new Vendor();
        }

        [HttpPost]
        public Vendor Post(Vendor record)
        {
            return this.baseController.Post(record) ?? new Vendor();
        }
    }
}
