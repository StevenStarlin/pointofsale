using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class SecurityGroupEndpoint : IEndpointBase<SecurityGroup>
    {
        private readonly SecurityGroup SecurityGroup;
        private readonly EndpointRepository<SecurityGroup> Gateway;

        public SecurityGroupEndpoint(SecurityGroup securityGroup)
        { 
            this.SecurityGroup = securityGroup ?? new SecurityGroup();
            this.Gateway ??= new EndpointRepository<SecurityGroup>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.SecurityGroup);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public SecurityGroup Get(int id)
        {
            return this.Gateway.Get(id) ?? new SecurityGroup();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.SecurityGroup.Id, this.SecurityGroup);
        }
    }
}
