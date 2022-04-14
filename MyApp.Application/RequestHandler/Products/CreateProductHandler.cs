using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Application.IService.ICategoryService;
using MyApp.Application.IService.IProductService;
using MyApp.Application.RequestCommand.Product;
using MyApp.Application.Response.Products;
using MyApp.Domain.Entities;

namespace MyApp.Application.RequestHandler.Products
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, ProductResponse>
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public CreateProductHandler(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task<ProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var productEntity = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
            Category categories = await _categoryService.GetCategoryByIdAsync(request.CategoryId);

            if (categories == null)
                throw new ApplicationException("The Category informed doesn't exist");

            var product = await _productService.Add(productEntity);
            var response = new ProductResponse();
            response.MapToResponse(product);

            return response;
        }
    }
}
