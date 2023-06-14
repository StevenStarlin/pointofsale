using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class OrderItemEndpoint : IEndpointBase<OrderItem>
    {
        private readonly OrderItem OrderItem;
        private readonly EndpointRepository<OrderItem> Gateway;

        public OrderItemEndpoint(OrderItem orderItem) 
        {
            this.OrderItem = orderItem ?? new OrderItem();
            this.Gateway ??= new EndpointRepository<OrderItem>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.OrderItem);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public OrderItem Get(int id)
        {
            return this.Gateway.Get(id) ?? new OrderItem();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.OrderItem.Id, this.OrderItem);
        }
    }
}
