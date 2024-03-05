using EcommerceNetBlazor.BlazorWebAssembly.Services.Contracts;
using EcommerceNetBlazor.Shared.DTOs;
using System.Net.Http.Json;

namespace EcommerceNetBlazor.BlazorWebAssembly.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly HttpClient _httpClient;

        public DashboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<DashboardDTO>> Resume()
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<DashboardDTO>>($"Dashboard/Resume");
        }
    }
}
