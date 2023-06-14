using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class SecurityGroupPermissionEndpoint : IEndpointBase<SecurityGroupPermission>
    {
        private readonly SecurityGroupPermission SecurityGroupPermission;
        private readonly EndpointRepository<SecurityGroupPermission> Gateway;

        public SecurityGroupPermissionEndpoint(SecurityGroupPermission securityGroupPermission)
        {
            this.SecurityGroupPermission = securityGroupPermission ?? new SecurityGroupPermission();
            this.Gateway ??= new EndpointRepository<SecurityGroupPermission>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.SecurityGroupPermission);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public SecurityGroupPermission Get(int id)
        {
            return this.Gateway.Get(id) ?? new SecurityGroupPermission();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.SecurityGroupPermission.Id, this.SecurityGroupPermission);
        }
    }
}
