using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class OrderStatusOptionEndpoint : IEndpointBase<OrderStatusOption>
    {
        private readonly OrderStatusOption OrderStatusOption;
        private readonly EndpointRepository<OrderStatusOption> Gateway;

        public OrderStatusOptionEndpoint(OrderStatusOption orderStatusOption)
        {
            this.OrderStatusOption = orderStatusOption ?? new OrderStatusOption();
            this.Gateway ??= new EndpointRepository<OrderStatusOption>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.OrderStatusOption);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public OrderStatusOption Get(int id)
        {
            return this.Gateway.Get(id) ?? new OrderStatusOption();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.OrderStatusOption.Id, this.OrderStatusOption);
        }
    }
}
