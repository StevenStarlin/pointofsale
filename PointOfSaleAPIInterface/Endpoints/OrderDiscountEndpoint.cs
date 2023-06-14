using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class OrderDiscountEndpoint : IEndpointBase<OrderDiscount>
    {
        private readonly OrderDiscount OrderDiscount;
        private readonly EndpointRepository<OrderDiscount> Gateway;

        public OrderDiscountEndpoint(OrderDiscount orderDiscount) 
        {
            this.OrderDiscount = orderDiscount ?? new OrderDiscount();
            this.Gateway ??= new EndpointRepository<OrderDiscount>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.OrderDiscount);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public OrderDiscount Get(int id)
        {
            return this.Gateway.Get(id) ?? new OrderDiscount();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.OrderDiscount.Id, this.OrderDiscount);
        }
    }
}
