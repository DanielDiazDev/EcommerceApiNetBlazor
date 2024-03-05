using EcommerceNetBlazor.Shared.DTOs;

namespace EcommerceNetBlazor.BlazorWebAssembly.Services.Contracts
{
    public interface IDashboardService
    {
        Task<ResponseDTO<DashboardDTO>> Resume();
    }
}
