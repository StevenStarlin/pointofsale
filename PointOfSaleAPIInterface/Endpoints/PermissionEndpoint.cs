using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class PermissionEndpoint : IEndpointBase<Permission>
    {
        private readonly Permission Permission;
        private readonly EndpointRepository<Permission> Gateway;

        public PermissionEndpoint(Permission permission) 
        {
            this.Permission = permission ?? new Permission();
            this.Gateway ??= new EndpointRepository<Permission>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.Permission);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public Permission Get(int id)
        {
            return this.Gateway.Get(id) ?? new Permission();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.Permission.Id, this.Permission);
        }
    }
}
