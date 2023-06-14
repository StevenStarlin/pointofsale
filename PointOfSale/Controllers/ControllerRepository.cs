using PointOfSale_Entities.Models;

namespace PointOfSale.Controllers
{
    public sealed class ContextRepository
    {
        private PointOfSaleContext? databaseContext;
        internal PointOfSaleContext DatabaseContext => databaseContext = databaseContext ?? new PointOfSaleContext();

        private static ContextRepository? instance;
        internal static ContextRepository Instance => instance = instance ?? new ContextRepository();
    }
}
