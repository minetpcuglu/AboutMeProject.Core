using AboutMeProject.Domain.Entities.Interface;
using AboutMeProject.Domain.Repository.Interface;
using AboutMeProject.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Infrastructure.Repository.BaseRepo
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity // => "IRepository"'de yazdığımız methodlara burada gövde kazandıracağız ve abstract olarak işaretlediğim "BaseRepository" sınıfını child sınıflarda çağıracağım.
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _table;

        public BaseRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._table = _context.Set<T>();
        }
        public async Task Insert(T t) => await _table.AddAsync(t);
        //public void Delete(T t) => _table.Remove(t); //** 

        public async Task<T> Get(Expression<Func<T, bool>> filter) => await _table.Where(filter).FirstOrDefaultAsync();
        public async Task<List<T>> GetAll() => await _table.ToListAsync();

        public async Task<T> GetById(int id) => await _table.FindAsync(id);

        public async Task<List<T>> GetListAll(Expression<Func<T, bool>> filter) => await _table.Where(filter).ToListAsync();
        public async Task Update(T t)
        {
            _table.Update(t);
            await _context.SaveChangesAsync();
        }
        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> expression) => await _table.Where(expression).FirstOrDefaultAsync();

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = query.Where(predicate);

            if (includeProperties.Any()) //Eğer eklenen includePropertiler varsa
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().SingleOrDefaultAsync();
        }

        public IQueryable<T> GetQueryable()
           => _table.AsQueryable()
               .AsNoTracking();


        public async Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector,
                                                                Expression<Func<T, bool>> expression = null, Func<IQueryable<T>,
                                                                IOrderedQueryable<T>> orderby = null, Func<IQueryable<T>,
                                                                IIncludableQueryable<T, object>> inculude = null,
                                                                Func<IQueryable<T>, IIncludableQueryable<T, object>> thenInculude = null,
                                                                bool disableTracking = true)
        {
            IQueryable<T> query = _table;

            if (disableTracking) query = query.AsNoTracking();
            if (inculude != null) query = inculude(query);
            if (expression != null) query = query.Where(expression);
            if (orderby != null) return await orderby(query).Select(selector).FirstOrDefaultAsync();
            else return await query.Select(selector).FirstOrDefaultAsync();
        }

        public async Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> selector,
                                                            Expression<Func<T, bool>> expression = null,
                                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
                                                            Func<IQueryable<T>, IIncludableQueryable<T, object>> inculude = null,
                                                            Func<IQueryable<T>, IIncludableQueryable<T, object>> thenInculude = null,
                                                            bool disableTracking = true)
        {
            IQueryable<T> query = _table;
            if (disableTracking) query = query.AsNoTracking();
            if (inculude != null) query = inculude(query);
            if (thenInculude != null) query = thenInculude(query);
            if (expression != null) query = query.Where(expression);
            if (orderby != null) return await orderby(query).Select(selector).ToListAsync();
            else return await query.Select(selector).ToListAsync();
        }

        public async Task<T> GetAsync2(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = query.Where(predicate);


            if (includeProperties.Any()) //Eğer eklenen includePropertiler varsa
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().SingleOrDefaultAsync();
        }


        public async Task Delete(T id)
        {
            await Task.Run(() => { _context.Set<T>().Remove(id); });
        }


        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }


    }
}
