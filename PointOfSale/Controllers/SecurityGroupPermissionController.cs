using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityGroupPermissionController : Controller, IController<SecurityGroupPermission>
    {
        private readonly ILogger<SecurityGroupPermission> _logger;
        private readonly ControllerBase<SecurityGroupPermission> baseController;

        public SecurityGroupPermissionController(ILogger<SecurityGroupPermission> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<SecurityGroupPermission>(logger);
        }

        [HttpDelete]
        public bool Delete(SecurityGroupPermission record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<SecurityGroupPermission> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public SecurityGroupPermission Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new SecurityGroupPermission();
        }

        [HttpPost]
        public SecurityGroupPermission Post(SecurityGroupPermission record)
        {
            return this.baseController.Post(record) ?? new SecurityGroupPermission();
        }
    }
}
