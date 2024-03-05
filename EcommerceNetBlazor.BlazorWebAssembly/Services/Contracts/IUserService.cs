using EcommerceNetBlazor.Shared.DTOs;

namespace EcommerceNetBlazor.BlazorWebAssembly.Services.Contracts
{
    public interface IUserService
    {
        Task<ResponseDTO<List<UserDTO>>> List(string role, string find);
        Task<ResponseDTO<UserDTO>> Get(string id);
        Task<ResponseDTO<SessionDTO>> Authorization(LoginDTO entity);
        Task<ResponseDTO<UserDTO>> Create(UserDTO entity);
        Task<ResponseDTO<bool>> Edit(UserDTO entity);
        Task<ResponseDTO<bool>> Delete(string id);
    }
}
