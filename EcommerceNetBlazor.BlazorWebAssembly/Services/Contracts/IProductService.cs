using EcommerceNetBlazor.Shared.DTOs;

namespace EcommerceNetBlazor.BlazorWebAssembly.Services.Contracts
{
    public interface IProductService
    {
        Task<ResponseDTO<List<ProductDTO>>> List(string find);
        Task<ResponseDTO<List<ProductDTO>>> Catalog(string category, string find);
        Task<ResponseDTO<ProductDTO>> Get(int id);
        Task<ResponseDTO<ProductDTO>> Create(ProductDTO entity);
        Task<ResponseDTO<bool>> Edit(ProductDTO entity);
        Task<ResponseDTO<bool>> Delete(int id);
    }
}
