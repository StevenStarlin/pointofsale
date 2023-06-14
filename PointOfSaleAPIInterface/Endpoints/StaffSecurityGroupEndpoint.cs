using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class StaffSecurityGroupEndpoint : IEndpointBase<StaffSecurityGroup>
    {
        private readonly StaffSecurityGroup StaffSecurityGroup;
        private readonly EndpointRepository<StaffSecurityGroup> Gateway;

        public StaffSecurityGroupEndpoint(StaffSecurityGroup staffSecurityGroup) 
        {
            this.StaffSecurityGroup = staffSecurityGroup ?? new StaffSecurityGroup();
            this.Gateway ??= new EndpointRepository<StaffSecurityGroup>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.StaffSecurityGroup);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public StaffSecurityGroup Get(int id)
        {
            return this.Gateway.Get(id) ?? new StaffSecurityGroup();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.StaffSecurityGroup.Id, this.StaffSecurityGroup);
        }
    }
}
