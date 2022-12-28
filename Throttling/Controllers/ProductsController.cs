using Microsoft.AspNetCore.Mvc;
using Throttling.Repository;
using Throttling.Atrribute;
using Throttling.Record;

namespace Throttling.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public IActionResult GetAllProducts() 
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]       
        public IActionResult GetProduct(Guid id)
        {
            var product = _repo.GetById(id);
            return product is not null ? Ok(product) : NotFound();
        }
    }
}