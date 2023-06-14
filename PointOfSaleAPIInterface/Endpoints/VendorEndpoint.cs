using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class VendorEndpoint : IEndpointBase<Vendor>
    {
        private readonly Vendor Vendor;
        private readonly EndpointRepository<Vendor> Gateway;

        public VendorEndpoint(Vendor vendor) 
        {
            this.Vendor = vendor ?? new Vendor();
            this.Gateway ??= new EndpointRepository<Vendor>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.Vendor);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public Vendor Get(int id)
        {
            return this.Gateway.Get(id) ?? new Vendor();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.Vendor.Id, this.Vendor);
        }
    }
}
