using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class ItemRecipeEndpoint : IEndpointBase<ItemRecipe>
    {
        private readonly ItemRecipe ItemRecipe;
        private readonly EndpointRepository<ItemRecipe> Gateway;

        public ItemRecipeEndpoint(ItemRecipe itemRecipe)
        {
            this.ItemRecipe = itemRecipe ?? new ItemRecipe();
            this.Gateway ??= new EndpointRepository<ItemRecipe>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.ItemRecipe);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public ItemRecipe Get(int id)
        {
            return this.Gateway.Get(id) ?? new ItemRecipe();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.ItemRecipe.Id, this.ItemRecipe);
        }
    }
}
