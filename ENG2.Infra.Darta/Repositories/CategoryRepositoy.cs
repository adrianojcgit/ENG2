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
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _categoryContext;
        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }

        public async Task<Category> Create(Category category)
        {
            _categoryContext.Add(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetById(int? id)
        {
            return await _categoryContext.Categories2.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryContext.Categories2.ToListAsync();
        }

        public async Task<Category> Remove(Category category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
    }
}
