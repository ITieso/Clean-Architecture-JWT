using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Application.IService.IProductService;
using MyApp.Application.RequestCommand.Products;
using MyApp.Application.Response.Products;
using MyApp.Domain.Entities;

namespace MyApp.Application.RequestHandler.Products
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, IEnumerable<ProductResponse>>
    {
        private readonly IProductService _productService;
        public GetAllProductsHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IEnumerable<ProductResponse>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetProductsAsync();
            if (!products.Any())
                throw new ApplicationException("Products not found");

            var response = ConvertToResponse(products);
            return response;

        }

        private IEnumerable<ProductResponse> ConvertToResponse(IEnumerable<Product> productsToConvert)
        {
            var response = new List<ProductResponse>();
            foreach (var item in productsToConvert)
            {
                var itemMappedToResponse = new ProductResponse();
                itemMappedToResponse.MapToResponse(item);
                response.Add(itemMappedToResponse);
            }
            return response;
        }
    }
}
