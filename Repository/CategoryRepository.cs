using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    using System.Linq;
    using System.Threading.Tasks;
    using Model;
    using Model.Interfaces;
    using AutoMapper;

    public class CategoryRepository : ICategoryRepository
    {
        DAL.ProductReviewContext context;
        public CategoryRepository(DAL.ProductReviewContext context)
        {
            this.context = context;
          
        }

        public Task AddAsync(Category item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Category>> GetAllAsync()
        {
            return Task<IQueryable<Category>>.Factory.StartNew(() =>
            {
                return context.Categories.ToArray().Select(c =>
                {
                    var res = AutoMapper.Mapper.Map<Model.Category>(c);
                    return res;
                }).AsQueryable();


            });
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
