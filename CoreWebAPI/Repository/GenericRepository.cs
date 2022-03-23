using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebAPI.Data;
using CoreWebAPI.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CoreWebAPI.Repository
{
    public class GenericRepository<T>: IGenericRepository<T> where T:class 
    {
        private readonly DatabaseContext _dbcontext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
            _dbSet = _dbcontext.Set<T>();
        }
        public async Task Delete(int id)
        {
            var entity =await  _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async  Task<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> expression = null, List<string> includes = null)
        {
            IQueryable<T> queryOut = _dbSet;
            if(includes !=null)
            {
                foreach(var property in includes)
                {
                    queryOut = queryOut.Include(property);
                }
            }
            return await queryOut.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, List<string> includes = null)
        {
            IQueryable<T> queryOut = _dbSet;
            if(expression !=null)
            {
                queryOut = _dbSet.Where(expression);
            }
            if (includes != null)
            {
                foreach (var property in includes)
                {
                    queryOut = queryOut.Include(property);
                }
            }
            if(orderby !=null)
            {
                queryOut =orderby(queryOut);
            }
            return await queryOut.AsNoTracking().ToListAsync();
        }

        public Task Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
