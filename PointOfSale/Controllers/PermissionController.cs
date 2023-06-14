using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : Controller, IController<Permission>
    {
        private readonly ILogger<Permission> _logger;
        private readonly ControllerBase<Permission> baseController;

        public PermissionController(ILogger<Permission> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<Permission>(logger);
        }

        [HttpDelete]
        public bool Delete(Permission record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<Permission> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public Permission Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new Permission();
        }

        [HttpPost]
        public Permission Post(Permission record)
        {
            return this.baseController.Post(record) ?? new Permission();
        }
    }
}
