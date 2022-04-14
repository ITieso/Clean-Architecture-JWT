using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.RequestCommand.Product;
using MyApp.Application.RequestCommand.Products;

namespace MyApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            GetAllProductsRequest request = new GetAllProductsRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("product/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            GetProductByIdRequest request = new GetProductByIdRequest();
            request.Id = id;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] UpdateProductRequest request)
        {
            request.Id = id;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            DeleteProductRequest request = new DeleteProductRequest();
            request.Id = id;
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
