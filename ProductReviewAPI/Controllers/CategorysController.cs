using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Interfaces;

namespace ProductReviewAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Categorys")]
    public class CategorysController : Controller
    {

        IProductReviewUnitOfWork productReviewUnitOfWork;
        ICategoryRepository categoryRepository;
        public CategorysController(IProductReviewUnitOfWork productReviewUnitOfWork)
        {
            this.productReviewUnitOfWork = productReviewUnitOfWork;
            this.categoryRepository = productReviewUnitOfWork.CategoryRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await categoryRepository.GetAllAsync();
                return Ok(res);
            }
            catch (Exception)
            { }
            return BadRequest();
        }

        // GET: api/Categorys/5
        [HttpGet("{id}", Name = "GetCategory")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Categorys
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Categorys/5
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
