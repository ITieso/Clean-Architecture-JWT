using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;
using MyApp.Infrastructure.Context;

namespace MyApp.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch(Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public async Task<IEnumerable<Product>> GetAll()
        {
            IEnumerable<Product> products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductByIdAsync(int? id)
        {
            Product product =  await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.Name == name);
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product> DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
