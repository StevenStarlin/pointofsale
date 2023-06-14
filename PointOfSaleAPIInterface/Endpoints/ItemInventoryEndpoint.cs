using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class ItemInventoryEndpoint : IEndpointBase<ItemInventory>
    {
        private readonly ItemInventory ItemInventory;
        private readonly EndpointRepository<ItemInventory> Gateway;

        public ItemInventoryEndpoint(ItemInventory itemInventory)
        {
            this.ItemInventory = itemInventory ?? new ItemInventory();
            this.Gateway ??= new EndpointRepository<ItemInventory>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.ItemInventory);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public ItemInventory Get(int id)
        {
            return this.Gateway.Get(id) ?? new ItemInventory();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.ItemInventory.Id, this.ItemInventory);
        }
    }
}
