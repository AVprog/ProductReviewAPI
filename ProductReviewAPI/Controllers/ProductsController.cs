using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Interfaces;
using Model;
using Microsoft.AspNetCore.Authorization;

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
                var res = (await productRepository.GetProductByCategoryId(id)).ToArray();
                return Ok(res);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }


       
        [HttpGet("{id}/review")]
        public async Task<IActionResult> ReviewOfProduct(int id)
        {
            try
            {
                Product p = await productRepository.GetByIdAsync(id);
                return Ok(p.Reviews);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }

        [Authorize]
        [HttpPost("addReview")]
        public async Task<IActionResult> AddReview([FromBody] AddReviewParam addReviewParam)
        {
            if (User.Identity.IsAuthenticated)
                return Ok(addReviewParam.textReview);
            else
                return Forbid();
        }

    }

    public class AddReviewParam
    {
      public  string textReview { get; set; }
    }
}
