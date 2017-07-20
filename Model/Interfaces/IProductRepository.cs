using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Interfaces
{
    using Model;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IQueryable<Product>> GetProductByCategoryId(int categoryId);
    }
}
