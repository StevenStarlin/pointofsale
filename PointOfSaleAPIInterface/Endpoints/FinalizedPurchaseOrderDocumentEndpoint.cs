using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class FinalizedPurchaseOrderDocumentEndpoint : IEndpointBase<FinalizedPurchaseOrderDocument>
    {
        private readonly FinalizedPurchaseOrderDocument FinalizedPurchaseOrderDocument;
        private readonly EndpointRepository<FinalizedPurchaseOrderDocument> Gateway;

        public FinalizedPurchaseOrderDocumentEndpoint(FinalizedPurchaseOrderDocument finalizedPurchaseOrderDocument)
        {
            this.FinalizedPurchaseOrderDocument = finalizedPurchaseOrderDocument ?? new FinalizedPurchaseOrderDocument();
            this.Gateway ??= new EndpointRepository<FinalizedPurchaseOrderDocument>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.FinalizedPurchaseOrderDocument);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public FinalizedPurchaseOrderDocument Get(int id)
        {
            return this.Gateway.Get(id) ?? new FinalizedPurchaseOrderDocument();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.FinalizedPurchaseOrderDocument.Id, this.FinalizedPurchaseOrderDocument);
        }
    }
}
