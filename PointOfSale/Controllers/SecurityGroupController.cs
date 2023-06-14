using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityGroupController : Controller, IController<SecurityGroup>
    {
        private readonly ILogger<SecurityGroup> _logger;
        private readonly ControllerBase<SecurityGroup> baseController;

        public SecurityGroupController(ILogger<SecurityGroup> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<SecurityGroup>(logger);
        }

        [HttpDelete]
        public bool Delete(SecurityGroup record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<SecurityGroup> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public SecurityGroup Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new SecurityGroup();
        }

        [HttpPost]
        public SecurityGroup Post(SecurityGroup record)
        {
            return this.baseController.Post(record) ?? new SecurityGroup();
        }
    }
}
