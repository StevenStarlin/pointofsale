using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class VendorTypeEndpoint : IEndpointBase<VendorType>
    {
        private readonly VendorType VendorType;
        private readonly EndpointRepository<VendorType> Gateway;

        public VendorTypeEndpoint(VendorType vendorType) 
        {
            this.VendorType = vendorType ?? new VendorType();
            this.Gateway ??= new EndpointRepository<VendorType>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.VendorType);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public VendorType Get(int id)
        {
            return this.Gateway.Get(id) ?? new VendorType();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.VendorType.Id, this.VendorType);
        }
    }
}
