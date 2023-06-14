using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public interface IEndpointBase<T>
    {
        RestResponse Create();

        T Get(int id);

        RestResponse Update();

        RestResponse Delete(int id);
    }
}