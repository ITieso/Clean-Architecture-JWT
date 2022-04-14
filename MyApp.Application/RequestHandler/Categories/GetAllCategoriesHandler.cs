using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Application.IService.ICategoryService;
using MyApp.Application.RequestCommand.Categories;
using MyApp.Application.Response.Categories;
using MyApp.Domain.Entities;

namespace MyApp.Application.RequestHandler.Categories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesRequest, IEnumerable<CategoryResponse>>
    {
        private readonly ICategoryService _categoryService;
        public GetAllCategoriesHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IEnumerable<CategoryResponse>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Category> categories = await _categoryService.GetCategoriesAsync();

            if (categories == null)
                throw new ApplicationException("Category Not Found");
            var response = ConvertToResponse(categories);

            return response;
        }

        private IEnumerable<CategoryResponse> ConvertToResponse(IEnumerable<Category> category)
        {
            var response = new List<CategoryResponse>();
            foreach( var item in category)
            {
                response.Add(new CategoryResponse
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return response;
        }
    }
}
