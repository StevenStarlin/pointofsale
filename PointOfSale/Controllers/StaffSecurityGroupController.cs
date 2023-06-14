using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffSecurityGroupController : Controller, IController<StaffSecurityGroup>
    {
        private readonly ILogger<StaffSecurityGroup> _logger;
        private readonly ControllerBase<StaffSecurityGroup> baseController;

        public StaffSecurityGroupController(ILogger<StaffSecurityGroup> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<StaffSecurityGroup>(logger);
        }

        [HttpDelete]
        public bool Delete(StaffSecurityGroup record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<StaffSecurityGroup> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public StaffSecurityGroup Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new StaffSecurityGroup();
        }

        [HttpPost]
        public StaffSecurityGroup Post(StaffSecurityGroup record)
        {
            return this.baseController.Post(record) ?? new StaffSecurityGroup();
        }
    }
}
