using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Interfaces;
using Model;

namespace ProductReviewAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductsController : Controller
    {

        IProductReviewUnitOfWork productReviewUnitOfWork;
        IProductRepository productRepository;
        public ProductsController(IProductReviewUnitOfWork productReviewUnitOfWork)
        {
            this.productReviewUnitOfWork = productReviewUnitOfWork;
            this.productRepository = productReviewUnitOfWork.ProductRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await productRepository.GetAllAsync());
            }
            catch (Exception)
            {

                
            }
            return BadRequest();

        }

        [HttpGet("Category/{id}")]
        public async Task<IActionResult> ProductByCategoryId(int id)
        {
            try
            {
                return Ok(await productRepository.GetProductByCategoryId(id));
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "GetProduct")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Product
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
