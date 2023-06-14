using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class OrderStatusEndpoint : IEndpointBase<OrderStatus>
    {
        private readonly OrderStatus OrderStatus;
        private readonly EndpointRepository<OrderStatus> Gateway;

        public OrderStatusEndpoint(OrderStatus orderStatus) 
        {
            this.OrderStatus = orderStatus ?? new OrderStatus();
            this.Gateway ??= new EndpointRepository<OrderStatus>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.OrderStatus);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public OrderStatus Get(int id)
        {
            return this.Gateway.Get(id) ??  new OrderStatus();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.OrderStatus.Id, this.OrderStatus);
        }
    }
}
