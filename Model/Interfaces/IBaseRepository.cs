using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IBaseRepository<T> where T:class
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T item);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(T item);

    }
}
