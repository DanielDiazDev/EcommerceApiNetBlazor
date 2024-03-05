using EcommerceNetBlazor.BlazorWebAssembly.Services.Contracts;
using EcommerceNetBlazor.Shared.DTOs;
using System.Data;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;

namespace EcommerceNetBlazor.BlazorWebAssembly.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<SessionDTO>> Authorization(LoginDTO entity)
        {
            var response = await _httpClient.PostAsJsonAsync("User/Authorization", entity);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SessionDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<UserDTO>> Create(UserDTO entity)
        {
            var response = await _httpClient.PostAsJsonAsync("User/Create", entity);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UserDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Delete(string id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"User/Delete/{id}");
        }

        public async Task<ResponseDTO<bool>> Edit(UserDTO entity)
        {
            var response = await _httpClient.PutAsJsonAsync("User/Edit", entity);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<UserDTO>> Get(string id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UserDTO>>($"User/Get/{id}");
        }

        public async Task<ResponseDTO<List<UserDTO>>> List(string role, string find)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UserDTO>>>($"User/List/{role}/{find}");
        }
    }
}
