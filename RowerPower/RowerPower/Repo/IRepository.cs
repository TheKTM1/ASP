namespace RowerPower.Repo {
    public interface IRepository<T, D> {
        T? Get(D id);
        void Delete(D id);
        void Update(T entity);
        void Add(T entity);
        List<T> GetAll();
    }
}