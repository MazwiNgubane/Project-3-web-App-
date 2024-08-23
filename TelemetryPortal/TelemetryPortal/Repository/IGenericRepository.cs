using System.Linq.Expressions;


public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    //Task<T> GetById(Guid id);
    Task AddAsync(T entity);
    void Update(T entity);
   
    Task SaveChanges();
    void Add(T entity);
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    T GetById(int id);
    void Remove(T entity);
    bool Any(Expression<Func<T, bool>> predicate);
}
