using System.Linq.Expressions;


public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    void Update(T entity);
   
    Task SaveChangesAsync();
    void Add(T entity);
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    T GetById(int id);
    void Remove(T entity);
    bool Any(Expression<Func<T, bool>> predicate);
}
