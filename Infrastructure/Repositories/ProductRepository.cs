using Application.InterfacesRepository;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Products.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Optionally log ex here
                throw new Exception($"Error fetching product by Id: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching all products: {ex.Message}", ex);
            }
        }

        public async Task AddAsync(Product product)
        {
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding product: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(Product product)
        {
            try
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating product: {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(Product product)
        {
            try
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting product: {ex.Message}", ex);
            }
        }
    }
}
