using Desafio_Final_Arquitetura_de_Software.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Final_Arquitetura_de_Software.Models.Repositories
{
    public class ProductsRepository
    {
        private readonly AppDbContext _context;

        public ProductsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<int> CountAllAsync()
        {
            var model = await _context.Products.ToListAsync();
            return model.Count;
        }

        public async Task<IEnumerable<Products>> GetAllByNameAsync(string name)
        {
            return await _context.Products
                .Where(p => p.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<Products?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task CreateAsync(Products products)
        {
            await _context.Products.AddAsync(products);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Products products)
        {
            _context.Products.Update(products);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Products products)
        {
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
        }
    }
}
