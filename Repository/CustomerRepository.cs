using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    using System.Linq;
    using System.Threading.Tasks;
    using Model;
    using Model.Interfaces;
    public class CustomerRepository : ICustomerRepository
    {
        DAL.ProductReviewContext context;
        public CustomerRepository(DAL.ProductReviewContext context)
        {
            this.context = context;
        }


        public Task AddAsync(Customer item)
        {
            throw new NotImplementedException();
        }


        public Task<bool> DeleteAsync(int id)
        {
            return Task<bool>.Factory.StartNew(() =>
            {
                var customer = context.Customers.FirstOrDefault(c => c.CustomerId == id);
                if (customer == null)
                {
                    return false;
                }
                context.Customers.Remove(customer);
                return true;
            });
        }

        public Task<IQueryable<Customer>> GetAllAsync()
        {
            return Task<IQueryable<Customer>>.Factory.StartNew(() =>
                    {
                        return context.Customers.Select(c => new Customer
                        {
                            CustomerId = c.CustomerId,
                            CustomerName = c.CustomerName,
                            PasswordHash = c.PasswordHash,
                            Email = c.Email
                        }).AsQueryable();
                    });
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            return Task<Customer>.Factory.StartNew(() =>
            {
                var customerDal = context.Customers.FirstOrDefault(c => c.CustomerId == id);
                return customerDal == null ? null :
                new Customer
                {
                    CustomerId = customerDal.CustomerId,
                    CustomerName = customerDal.CustomerName,
                    Email = customerDal.Email,
                    PasswordHash = customerDal.PasswordHash
                };
            });
        }

        public Task<bool> UpdateAsync(Customer item)
        {

            return Task<bool>.Factory.StartNew(() =>
            {
             var customerDal = context.Customers.FirstOrDefault(c => c.CustomerId == item.CustomerId);
             if (customerDal == null)
             {
                 return false;
             }
             customerDal.CustomerName = item.CustomerName ?? customerDal.CustomerName;
             customerDal.Email = item.Email ?? customerDal.Email;
             customerDal.PasswordHash = item.PasswordHash ?? customerDal.PasswordHash;
             return true;

         });
        }
    }
}
