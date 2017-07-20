using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    using System.Linq;
    using System.Threading.Tasks;
    using Model;
    using Model.Interfaces;
    public class ProductRepository : IProductRepository
    {
        DAL.ProductReviewContext context;
        public ProductRepository(DAL.ProductReviewContext context)
        {
            this.context = context;
        }

        public Task AddAsync(Product item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Product>> GetAllAsync()
        {
            return Task<IQueryable<Product>>.Factory.StartNew(() =>
            {
                return context.Products.Select(p => new Model.Product
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    ProductDescription = p.ProductDescription,
                    CategoryId = p.CategoryId
                });
            });
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Product item)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Product>> GetProductByCategoryId(int categoryId)
        {
            return Task<IQueryable<Product>>.Factory.StartNew(() =>
            {
                return context.Products.Where(p=>p.CategoryId==categoryId).Select(p => new Model.Product
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    ProductDescription = p.ProductDescription,
                    CategoryId = p.CategoryId
                }).AsQueryable();
            });
        }
    }
}
