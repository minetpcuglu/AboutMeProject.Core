using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Services.Interface
{
   public interface IGenericService<T>
    {
        Task<List<T>> GetAll();
        Task Add(T t);
        Task<T> GetById(int id);
        Task Update(T t);
       
        Task<bool> DeleteAsync(int id);
    }
}
