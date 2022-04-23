using AboutMeProject.Domain.Entities.Interface;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Domain.Repository.Interface
{
    // Repository: Temel olarak veritabanı sorgulama işlemlerinin bir merkezsen yapılmasını sağlayarak iş katmamına bu işlererin taşınmasını önler bu şekilde sorgu ve kod tekrarını engelleriz.
    public interface IBaseRepository<T> where T : IBaseEntity
    {

        Task Insert(T t);
        Task Delete(T t);
        Task Update(T t);
     
        IQueryable<T> GetQueryable();
        Task<T> FirstOrDefault(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAll(); // Asenkron programlama yapmak istediğimiz methodlarımızı "TASK" olarak işaretlenir.
        Task<List<T>> GetListAll(Expression<Func<T, bool>> filter);  //filter 
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate); //Veritabanına kaydetmek istediğimiz nesneleri daha önceden varmı sorgulamak için oluşturulmuştur.
        Task<T> Get(Expression<Func<T, bool>> filter);  //dışarıdann bir şart alıcak
        Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector,
                                                        Expression<Func<T, bool>> expression = null,
                                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
                                                        Func<IQueryable<T>, IIncludableQueryable<T, object>> inculude = null,
                                                        Func<IQueryable<T>, IIncludableQueryable<T, object>> thenInculude = null,
                                                        bool disableTracking = true);

        Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> selector,
                                                     Expression<Func<T, bool>> expression = null,
                                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
                                                     Func<IQueryable<T>, IIncludableQueryable<T, object>> inculude = null,
                                                     Func<IQueryable<T>, IIncludableQueryable<T, object>> thenInculude = null,
                                                     bool disableTracking = true);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetById(int id);
    }
}
