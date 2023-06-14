using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class FinalizedOrderDocumentEndpoint : IEndpointBase<FinalizedOrderDocument>
    {
        private readonly FinalizedOrderDocument FinalizedOrderDocument;
        private readonly EndpointRepository<FinalizedOrderDocument> Gateway;

        public FinalizedOrderDocumentEndpoint(FinalizedOrderDocument finalizedOrderDocument)
        {
            this.FinalizedOrderDocument = finalizedOrderDocument ?? new FinalizedOrderDocument();
            this.Gateway ??= new EndpointRepository<FinalizedOrderDocument>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.FinalizedOrderDocument);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public FinalizedOrderDocument Get(int id)
        {
            return this.Gateway.Get(id) ?? new FinalizedOrderDocument();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.FinalizedOrderDocument.Id, this.FinalizedOrderDocument);
        }
    }
}
