using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class SettingEndpoint : IEndpointBase<Setting>
    {
        private readonly Setting Setting;
        private readonly EndpointRepository<Setting> Gateway;

        public SettingEndpoint(Setting setting) 
        {
            this.Setting = setting ?? new Setting();
            this.Gateway ??= new EndpointRepository<Setting>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.Setting);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public Setting Get(int id)
        {
            return this.Get(id) ?? new Setting();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.Setting.Id, this.Setting);
        }
    }
}
