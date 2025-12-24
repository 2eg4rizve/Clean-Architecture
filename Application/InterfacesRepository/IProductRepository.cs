using Domain.Entities;

namespace Application.InterfacesRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        // Product-specific queries go here
    }
}
