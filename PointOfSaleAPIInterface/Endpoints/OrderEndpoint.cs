using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class OrderEndpoint : IEndpointBase<Order>
    {
        private readonly Order Order;
        private readonly EndpointRepository<Order> Gateway;

        public OrderEndpoint(Order order) 
        {
            this.Order = order ?? new Order();
            this.Gateway ??= new EndpointRepository<Order>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.Order);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public Order Get(int id)
        {
            return this.Gateway.Get(id) ?? new Order();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.Order.Id, this.Order);
        }
    }
}
