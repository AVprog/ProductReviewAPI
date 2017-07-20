using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Interfaces;
using Model;

namespace ProductReviewAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        IProductReviewUnitOfWork productReviewUnitOfWork;
        ICustomerRepository customerRepository;
        public CustomersController(IProductReviewUnitOfWork productReviewUnitOfWork)
        {
            this.productReviewUnitOfWork = productReviewUnitOfWork;
            this.customerRepository = productReviewUnitOfWork.CustomerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await customerRepository.GetAllAsync();
                return Ok(res);
            }
            catch (Exception)
            { }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Customer customer = await customerRepository.GetByIdAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(customer);
            }
            catch (Exception)
            {
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await customerRepository.DeleteAsync(id))
                {
                    await productReviewUnitOfWork.SaveAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
            }
            return BadRequest();
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody]Customer customer)
        {
            try
            {
                await customerRepository.UpdateAsync(customer);
                if (await productReviewUnitOfWork.SaveAsync())
                    return Ok(customer);
            }
            catch (Exception)
            {  }
            return BadRequest();
        }
    }
}