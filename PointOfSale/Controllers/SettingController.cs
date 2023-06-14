using Microsoft.AspNetCore.Mvc;
using PointOfSale_Entities.Models;
using PointOfSaleAPI.Controllers;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettingController : Controller, IController<Setting>
    {
        private readonly ILogger<Setting> _logger;
        private readonly ControllerBase<Setting> baseController;

        public SettingController(ILogger<Setting> logger)
        {
            _logger = logger;

            this.baseController ??= new ControllerBase<Setting>(logger);
        }

        [HttpDelete]
        public bool Delete(Setting record)
        {
            return this.baseController.Delete(record); 
        }

        [HttpGet]
        public IEnumerable<Setting> Get(int? recordsPerPage, int? pageNumber)
        {
            return this.baseController.Get(recordsPerPage, pageNumber);
        }

        [HttpGet("{id:int}")]
        public Setting Get(int recordID)
        {
            return this.baseController.Get(recordID) ?? new Setting();
        }

        [HttpPost]
        public Setting Post(Setting record)
        {
            return this.baseController.Post(record) ?? new Setting();
        }
    }
}
