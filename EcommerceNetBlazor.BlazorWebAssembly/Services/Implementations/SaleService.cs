using EcommerceNetBlazor.BlazorWebAssembly.Services.Contracts;
using EcommerceNetBlazor.Shared.DTOs;
using System.Net.Http.Json;
using System.Reflection;

namespace EcommerceNetBlazor.BlazorWebAssembly.Services.Implementations
{
    public class SaleService : ISaleService
    {
        private readonly HttpClient _httpClient;
        public SaleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<SaleDTO>> Register(SaleDTO entity)
        {
            var response = await _httpClient.PostAsJsonAsync("Sale/Register", entity);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SaleDTO>>();
            return result!;
        }
    }
}
