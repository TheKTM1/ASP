namespace RowerPower.Repo {
    public interface IRepository<T> {
        T? Get(int id);
        void Delete(int id);
        void Update(T entity);
        void Add(T entity);
        List<T> GetAll();
    }
}