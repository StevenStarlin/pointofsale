using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class PurchaseOrderItemEndpoint : IEndpointBase<PurchaseOrderItem>
    {
        private readonly PurchaseOrderItem PurchaseOrderItem;
        private readonly EndpointRepository<PurchaseOrderItem> Gateway;

        public PurchaseOrderItemEndpoint(PurchaseOrderItem purchaseOrderItem) 
        { 
            this.PurchaseOrderItem = purchaseOrderItem ?? new PurchaseOrderItem();
            this.Gateway ??= new EndpointRepository<PurchaseOrderItem>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.PurchaseOrderItem);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public PurchaseOrderItem Get(int id)
        {
            return this.Gateway.Get(id) ?? new PurchaseOrderItem();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.PurchaseOrderItem.Id, this.PurchaseOrderItem);
        }
    }
}
