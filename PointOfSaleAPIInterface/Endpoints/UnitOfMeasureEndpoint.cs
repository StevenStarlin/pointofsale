using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class UnitOfMeasureEndpoint : IEndpointBase<UnitOfMeasure>
    {
        private readonly UnitOfMeasure UnitOfMeasure;
        private readonly EndpointRepository<UnitOfMeasure> Gateway;

        public UnitOfMeasureEndpoint(UnitOfMeasure unitOfMeasure) 
        {
            this.UnitOfMeasure = unitOfMeasure ?? new UnitOfMeasure();
            this.Gateway ??= new EndpointRepository<UnitOfMeasure>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.UnitOfMeasure);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public UnitOfMeasure Get(int id)
        {
            return this.Gateway.Get(id) ?? new UnitOfMeasure();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.UnitOfMeasure.Id, this.UnitOfMeasure);
        }
    }
}
