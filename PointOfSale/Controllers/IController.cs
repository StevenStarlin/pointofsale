namespace PointOfSale.Controllers
{
    public interface IController<T>
    {
        public IEnumerable<T> Get(int? recordsPerPage, int? pageNumber);

        public T Get(int recordID);

        public T Post(T record);

        public bool Delete(T record);
    }
}
