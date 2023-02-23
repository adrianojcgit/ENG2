using ENG2.Domain.Entities;
using ENG2.Domain.Interfaces;
using ENG2.Infra.Darta.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENG2.Infra.Darta.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _productContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _productContext.Products2.FindAsync(id);
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            //eager loading
            return await _productContext.Products2.Include(c => c.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productContext.Products2.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}
