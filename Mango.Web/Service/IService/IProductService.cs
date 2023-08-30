using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDto?> GetProductAsync(string productCode);
        Task<ResponseDto?> GetAllAsync();
        Task<ResponseDto?> GetProductByIdAsync(int productId);
        Task<ResponseDto?> CreateProductAsync(ProductDto productDto);
        Task<ResponseDto?> UpdateProductAsync(ProductDto productDto);
        Task<ResponseDto?> DeleteProductAsync(int productId);
    }
}
