using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TelemetryPortal.Data;


public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly TechtrendsContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(TechtrendsContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetById(Guid id)
    {
        return  _context.Set<T>().Find(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

 

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);

    }
    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }
    public  T GetById(int id)
    {
        return  _context.Set<T>().Find(id);
    }
    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    public bool Any(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Any(predicate);
    }
}
