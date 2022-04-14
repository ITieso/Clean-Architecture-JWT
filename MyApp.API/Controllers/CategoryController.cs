using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.RequestCommand.Categories;

namespace MyApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            GetAllCategoriesRequest request = new GetAllCategoriesRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("/create")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteCategoryRequest request = new DeleteCategoryRequest();
            request.Id = id;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("/update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequest request)
        {
            request.Id = id;
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
