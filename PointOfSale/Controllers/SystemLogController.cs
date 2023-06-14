using Microsoft.AspNetCore.Mvc;

using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemLogController : Controller, IController<SystemLog>
    {
        private readonly ILogger<SystemLog> _logger;
        private readonly ControllerBase<SystemLog> baseController;

        public SystemLogController(ILogger<SystemLog> logger)
        {
            _logger = logger;
            this.baseController ??= new ControllerBase<SystemLog>(logger);
        }

        [HttpDelete]
        public bool Delete(SystemLog record)
        {
            return this.baseController.Delete(record);
        }

        [HttpGet]
        public IEnumerable<SystemLog> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public SystemLog Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new SystemLog();
        }

        [HttpPost]
        public SystemLog Post(SystemLog record)
        {
            return this.baseController.Post(record) ?? new SystemLog();
        }
    }
}
