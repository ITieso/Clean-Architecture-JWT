using MediatR;
using MyApp.Application.Response.Categories;

namespace MyApp.Application.RequestCommand.Categories
{
    public class CreateCategoryRequest : IRequest<CategoryResponse>
    {
        public string Name { get; set; }

        public CreateCategoryRequest()
        {

        }
    }
}
