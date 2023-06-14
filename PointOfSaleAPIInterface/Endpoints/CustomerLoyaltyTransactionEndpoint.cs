using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class CustomerLoyaltyTransactionEndpoint : IEndpointBase<CustomerLoyaltyTransaction>
    {
        private readonly CustomerLoyaltyTransaction CustomerLoyaltyTransaction;
        private readonly EndpointRepository<CustomerLoyaltyTransaction> Gateway;

        public CustomerLoyaltyTransactionEndpoint(CustomerLoyaltyTransaction customerLoyaltyTransaction)
        {
            this.CustomerLoyaltyTransaction = customerLoyaltyTransaction ?? new CustomerLoyaltyTransaction();
            this.Gateway ??= new EndpointRepository<CustomerLoyaltyTransaction>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.CustomerLoyaltyTransaction);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public CustomerLoyaltyTransaction Get(int id)
        {
            return this.Gateway.Get(id) ?? new CustomerLoyaltyTransaction();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.CustomerLoyaltyTransaction.Id, this.CustomerLoyaltyTransaction);
        }
    }
}
