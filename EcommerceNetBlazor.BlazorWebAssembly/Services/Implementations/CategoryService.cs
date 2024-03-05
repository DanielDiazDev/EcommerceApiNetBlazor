using EcommerceNetBlazor.BlazorWebAssembly.Services.Contracts;
using EcommerceNetBlazor.Shared.DTOs;
using System.Net.Http.Json;
using System.Reflection;

namespace EcommerceNetBlazor.BlazorWebAssembly.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<CategoryDTO>> Create(CategoryDTO entity)
        {
            var response = await _httpClient.PostAsJsonAsync("Category/Create", entity);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoryDTO>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Delete(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Category/Delete/{id}");
        }

        public async Task<ResponseDTO<bool>> Edit(CategoryDTO entity)
        {
            var response = await _httpClient.PutAsJsonAsync("Category/Edit", entity);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<CategoryDTO>> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoryDTO>>($"Category/Get/{id}");

        }

        public async Task<ResponseDTO<List<CategoryDTO>>> List(string find)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoryDTO>>>($"Category/List/{find}");
        }
    }
}
