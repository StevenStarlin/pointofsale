using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class PurchaseOrderEndpoint : IEndpointBase<PurchaseOrder>
    {
        private readonly PurchaseOrder PurchaseOrder;
        private readonly EndpointRepository<PurchaseOrder> Gateway;

        public PurchaseOrderEndpoint(PurchaseOrder purchaseOrder) 
        {
            this.PurchaseOrder = purchaseOrder ?? new PurchaseOrder();
            this.Gateway ??= new EndpointRepository<PurchaseOrder>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.PurchaseOrder);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public PurchaseOrder Get(int id)
        {
            return this.Gateway.Get(id) ?? new PurchaseOrder();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.PurchaseOrder.Id, this.PurchaseOrder);
        }
    }
}
