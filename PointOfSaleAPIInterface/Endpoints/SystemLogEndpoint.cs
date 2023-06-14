using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    internal class SystemLogEndpoint : IEndpointBase<SystemLog>
    {
        private readonly SystemLog SystemLog;
        private readonly EndpointRepository<SystemLog> Gateway;

        public SystemLogEndpoint(SystemLog systemLog) 
        {
            this.SystemLog = systemLog ?? new SystemLog();
            this.Gateway ??= new EndpointRepository<SystemLog>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.SystemLog);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public SystemLog Get(int id)
        {
            return this.Gateway.Get(id) ?? new SystemLog();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.SystemLog.Id, this.SystemLog);
        }
    }
}
