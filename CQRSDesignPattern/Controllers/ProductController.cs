using CQRSDesignPattern.Commands;
using CQRSDesignPattern.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Data.Entity;
using System.Threading.Tasks;

namespace CQRSDesignPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            GetProduct.Response response = await _mediator.Send(new GetProduct.Query(id));
            return response == null ? NotFound() : Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            int response = await _mediator.Send(new AddProduct.Command(product));
            return response == 0 ? BadRequest() : Ok(response);
        }
    }
}
