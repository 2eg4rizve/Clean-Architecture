using Application.Common;
using Application.Dtos.RequestDtos;
using Application.Dtos.ResponseDtos;

namespace Application.InterfacesService
{
    public interface IProductService
    {
        Task<ApiResponse<ProductResponse>> GetProductByIdAsync(int id);
        Task<ApiResponse<IEnumerable<ProductResponse>>> GetAllProductsAsync();
        Task<ApiResponse<ProductResponse>> CreateProductAsync(ProductRequest request);
        Task<ApiResponse<ProductResponse>> UpdateProductAsync(int id, ProductRequest request);
        Task<ApiResponse<bool>> DeleteProductAsync(int id);
    }
}
