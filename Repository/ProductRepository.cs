using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    using System.Linq;
    using System.Threading.Tasks;
    using Model;
    using Model.Interfaces;
    using Microsoft.EntityFrameworkCore;

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
                    CategoryId = p.CategoryId,
                    Reviews = p.Reviews.ToArray().Select<DAL.Review, Model.Review>(rw => new Model.Review()
                    {
                        CustomerId = rw.CustomerId,
                        ProductId = rw.ProductId,
                        Rate = rw.Rate,
                        ReviewDescription = rw.ReviewDescription,
                        ReviewId = rw.ReviewId
                    })
                }).AsQueryable();

            });
        }

        public  Task<Product>  GetByIdAsync(int id)
        {

            return Task<Product>.Factory.StartNew(() =>
            {
                var p = context.Products.First(p1 => p1.ProductId == id);
                context.Reviews.Load();
                var r = p.Reviews.ToArray().Select<DAL.Review, Model.Review>(rw => new Model.Review()
                {
                    CustomerId = rw.CustomerId,
                    ProductId = rw.ProductId,
                    Rate = rw.Rate,
                    ReviewDescription = rw.ReviewDescription,
                    ReviewId = rw.ReviewId
                });


                return new Model.Product()
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    ProductDescription = p.ProductDescription,
                    CategoryId = p.CategoryId,
                    Reviews = r
                };

            });

        }

        public Task<bool> UpdateAsync(Product item)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Product>> GetProductByCategoryId(int categoryId)
        {
            return Task<IQueryable<Product>>.Factory.StartNew(() =>
            {
                return context.Products.Where(p => p.CategoryId == categoryId).ToArray().Select(p => new Model.Product
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    ProductDescription = p.ProductDescription,
                    CategoryId = p.CategoryId,
                    Reviews = p.Reviews.ToArray().Select<DAL.Review, Model.Review>(rw => new Model.Review()
                    {
                        CustomerId = rw.CustomerId,
                        ProductId = rw.ProductId,
                        Rate = rw.Rate,
                        ReviewDescription = rw.ReviewDescription,
                        ReviewId = rw.ReviewId
                    })

                }).AsQueryable();
            });
        }
}
}


//return new Model.Review()
//                        {
//                            CustomerId = rw.CustomerId,
//                            ProductId = rw.ProductId,
//                            Rate = rw.Rate,
//                            ReviewDescription = rw.ReviewDescription,
//                            ReviewId = rw.ReviewId
//                        };