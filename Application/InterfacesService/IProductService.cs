using Application.Common;
using Application.Dtos.RequestDtos;
using Application.Dtos.ResponseDtos;

namespace Application.InterfacesService
{
    public interface IProductService
    {
        Task<ApiResponse<ProductResponse>> GetProductByIdAsync(Guid id);
        Task<ApiResponse<IEnumerable<ProductResponse>>> GetAllProductsAsync();
        Task<ApiResponse<ProductResponse>> CreateProductAsync(ProductRequest request);
        Task<ApiResponse<ProductResponse>> UpdateProductAsync(Guid id, ProductRequest request);
        Task<ApiResponse<bool>> DeleteProductAsync(Guid id);
    }
}
