using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Application.IService.ICategoryService;
using MyApp.Application.RequestCommand.Categories;
using MyApp.Application.Response.Categories;
using MyApp.Domain.Entities;

namespace MyApp.Application.RequestHandler.Categories
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, CategoryResponse>
    {
        private readonly ICategoryService _categoryService;
        public CreateCategoryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<CategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            Category category = new Category(request.Name);
            var registered = await _categoryService.Create(category);

            CategoryResponse response = new CategoryResponse
            {
                Id = registered.Id,
                Name = registered.Name
            };

            return response;
        }
    }
}
