using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Application.IService.IProductService;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;

namespace MyApp.Application.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Add(Product product)
        {
            try
            {
             var productEntity = await _productRepository.CreateAsync(product);
             return productEntity;
            }
            catch
            {
                throw new ApplicationException("Ops! Have had a problem to create a new product");
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.GetAll();
        }
        public async Task<Product> Update(Product product)
        {
            var productCurrent = await _productRepository.GetProductByIdAsync(product.Id);
            productCurrent.Name = product.Name;
            productCurrent.Description = product.Description;
            productCurrent.Price = product.Price;
            productCurrent.Stock = product.Stock;
            productCurrent.Image = product.Image;
            productCurrent.CategoryId = product.CategoryId;

            var response = await _productRepository.UpdateAsync(productCurrent);
            return response;
        }

        public async Task<Product> Remove(Product product)
        {
            return await _productRepository.DeleteAsync(product);
        }

    }
}
