using EcommerceNetBlazor.BlazorWebAssembly.Services.Contracts;
using EcommerceNetBlazor.Shared.DTOs;
using System.Net.Http.Json;
using System.Reflection;

namespace EcommerceNetBlazor.BlazorWebAssembly.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<ProductDTO>>> Catalog(string category, string find)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductDTO>>>($"Product/Catalog/{category}/{find}");
        }

        public async Task<ResponseDTO<ProductDTO>> Create(ProductDTO entity)
        {
            var response = await _httpClient.PostAsJsonAsync("Product/Create", entity);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ProductDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Delete(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Product/Delete/{id}");
        }

        public async Task<ResponseDTO<bool>> Edit(ProductDTO entity)
        {
            var response = await _httpClient.PutAsJsonAsync("Product/Edit", entity);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<ProductDTO>> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<ProductDTO>>($"Product/Get/{id}");
        }

        public async Task<ResponseDTO<List<ProductDTO>>> List(string find)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductDTO>>>($"Product/List/{find}");
        }
    }
}
