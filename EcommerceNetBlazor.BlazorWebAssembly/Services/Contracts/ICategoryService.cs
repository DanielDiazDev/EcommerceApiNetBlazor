using EcommerceNetBlazor.Shared.DTOs;

namespace EcommerceNetBlazor.BlazorWebAssembly.Services.Contracts
{
    public interface ICategoryService
    {
        Task<ResponseDTO<List<CategoryDTO>>> List(string find);
        Task<ResponseDTO<CategoryDTO>> Get(int id);
        Task<ResponseDTO<CategoryDTO>> Create(CategoryDTO entity);
        Task<ResponseDTO<bool>> Edit(CategoryDTO entity);
        Task<ResponseDTO<bool>> Delete(int id);
    }
}
