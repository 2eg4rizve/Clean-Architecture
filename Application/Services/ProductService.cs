using AutoMapper;
using Application.Common;
using Application.Dtos.RequestDtos;
using Application.Dtos.ResponseDtos;
using Application.InterfacesRepository;
using Application.InterfacesService;
using Domain.Entities;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProductResponse>> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                return new ApiResponse<ProductResponse> { Success = false, Message = "Product not found" };

            return new ApiResponse<ProductResponse>
            {
                Success = true,
                Data = _mapper.Map<ProductResponse>(product)
            };
        }

        public async Task<ApiResponse<IEnumerable<ProductResponse>>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllAsync();
            return new ApiResponse<IEnumerable<ProductResponse>>
            {
                Success = true,
                Data = _mapper.Map<IEnumerable<ProductResponse>>(products)
            };
        }

        public async Task<ApiResponse<ProductResponse>> CreateProductAsync(ProductRequest request)
        {
            var product = _mapper.Map<Product>(request);
            await _repository.AddAsync(product);

            return new ApiResponse<ProductResponse>
            {
                Success = true,
                Message = "Product created successfully",
                Data = _mapper.Map<ProductResponse>(product)
            };
        }

        public async Task<ApiResponse<ProductResponse>> UpdateProductAsync(int id, ProductRequest request)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                return new ApiResponse<ProductResponse> { Success = false, Message = "Product not found" };

            _mapper.Map(request, product);
            await _repository.UpdateAsync(product);

            return new ApiResponse<ProductResponse>
            {
                Success = true,
                Message = "Product updated successfully",
                Data = _mapper.Map<ProductResponse>(product)
            };
        }

        public async Task<ApiResponse<bool>> DeleteProductAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                return new ApiResponse<bool> { Success = false, Message = "Product not found" };

            await _repository.DeleteAsync(product);

            return new ApiResponse<bool>
            {
                Success = true,
                Message = "Product deleted successfully",
                Data = true
            };
        }
    }
}
