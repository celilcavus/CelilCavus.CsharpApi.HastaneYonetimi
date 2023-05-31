namespace CelilCavus.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        void Remove(int id);
        void Update(T item);
        T GetById(int id);
        List<T> GetAll();
    }
}