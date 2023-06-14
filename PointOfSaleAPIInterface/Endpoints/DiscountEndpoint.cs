using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class DiscountEndpoint : IEndpointBase<Discount>
    {
        private readonly Discount Discount;
        private readonly EndpointRepository<Discount> Gateway;

        public DiscountEndpoint(Discount discount) 
        {
            this.Discount = discount ?? new Discount();
            this.Gateway ??= new EndpointRepository<Discount>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.Discount);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public Discount Get(int id)
        {
            return this.Gateway.Get(id) ?? new Discount();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.Discount.Id, this.Discount);
        }
    }
}
