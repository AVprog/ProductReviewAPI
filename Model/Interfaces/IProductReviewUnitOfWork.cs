using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IProductReviewUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        Task<bool> SaveAsync();
    }
}
