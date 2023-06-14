using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class CustomerEndpoint : IEndpointBase<Customer>
    {
        private readonly Customer Customer;
        private readonly EndpointRepository<Customer> Gateway;

        public CustomerEndpoint(Customer customer)
        {
            this.Customer = customer ?? new Customer();
            this.Gateway ??= new EndpointRepository<Customer>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(Customer);
        }

        public Customer Get(int id)
        {
            return this.Gateway.Get(id) ?? new Customer();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.Customer.Id, Customer);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }
    }
}