using PointOfSale_Entities.Models;
using RestSharp;

namespace PointOfSaleAPIInterface.Endpoints
{
    public class StaffEndpoint : IEndpointBase<Staff>
    {
        private readonly Staff Staff;
        private readonly EndpointRepository<Staff> Gateway;

        public StaffEndpoint(Staff staff) 
        { 
            this.Staff = staff ?? new Staff();
            this.Gateway ??= new EndpointRepository<Staff>();
        }

        public RestResponse Create()
        {
            return this.Gateway.Create(this.Staff);
        }

        public RestResponse Delete(int id)
        {
            return this.Gateway.Delete(id);
        }

        public Staff Get(int id)
        {
            return this.Gateway.Get(id) ?? new Staff();
        }

        public RestResponse Update()
        {
            return this.Gateway.Update(this.Staff.Id, this.Staff);
        }
    }
}
