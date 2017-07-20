using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    using System.Threading.Tasks;
    using Model.Interfaces;
    using DAL;
    using AutoMapper;

    public class ProductReviewUnitOfWork : IProductReviewUnitOfWork
    {
        ProductReviewContext context;
        CategoryRepository categoryRepository;
        CustomerRepository customerRepository;
        ProductRepository productRepository;

        public ProductReviewUnitOfWork(ProductReviewContext context)
        {
            this.context = context;
            Mapper.Initialize(cfg => cfg.CreateMap<DAL.Category, Model.Category>());
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (customerRepository == null)
                {
                    customerRepository = new Repository.CustomerRepository(context);
                }
                return customerRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new Repository.CategoryRepository(context);
                }
                return categoryRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new Repository.ProductRepository(context);
                }
                return productRepository;
            }
        }

        public Task<bool> SaveAsync()
        {
            return Task<bool>.Factory.StartNew(() =>
            {
                return context.SaveChanges() > 0;
            });
        }
    }
}
