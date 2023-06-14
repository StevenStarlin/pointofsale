using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class ItemEndpoint : IEndpointBase<Item>
    {
        private readonly Item Item;
        private readonly EndpointRepository<Item> Gateway;

        public ItemEndpoint(Item item) 
        {
            this.Item = item ?? new Item();
            this.Gateway ??= new EndpointRepository<Item>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.Item);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public Item Get(int id)
        {
            return this.Gateway.Get(id) ?? new Item();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.Item.Id, this.Item);
        }
    }
}
