using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffController : Controller, IController<Staff>
    {
        private readonly ILogger<Staff> _logger;
        private readonly ControllerBase<Staff> baseController;

        public StaffController(ILogger<Staff> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<Staff>(logger);
        }

        [HttpDelete]
        public bool Delete(Staff record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<Staff> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public Staff Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new Staff();
        }

        [HttpPost]
        public Staff Post(Staff record)
        {
            return this.baseController.Post(record) ?? new Staff();
        }
    }
}