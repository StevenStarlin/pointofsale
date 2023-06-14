using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class CustomerLoyaltyEndpoint : IEndpointBase<CustomerLoyalty>
    {
        private readonly CustomerLoyalty CustomerLoyalty;
        private readonly EndpointRepository<CustomerLoyalty> Gateway;

        public CustomerLoyaltyEndpoint(CustomerLoyalty customerLoyalty)
        {
            this.CustomerLoyalty = customerLoyalty ?? new CustomerLoyalty();
            this.Gateway = this.Gateway ?? new EndpointRepository<CustomerLoyalty>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.CustomerLoyalty);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public CustomerLoyalty Get(int id)
        {
            return this.Gateway.Get(id) ?? new CustomerLoyalty();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.CustomerLoyalty.Id, this.CustomerLoyalty);
        }
    }
}
