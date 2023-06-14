using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class TableEndpoint : IEndpointBase<Table>
    {
        private readonly Table Table;
        private readonly EndpointRepository<Table> Gateway;

        public TableEndpoint(Table table)
        {
            this.Table = table ?? new Table();
            this.Gateway ??= new EndpointRepository<Table>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.Table);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public Table Get(int id)
        {
            return this.Gateway.Get(id) ?? new Table();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.Table.Id, this.Table);
        }
    }
}
