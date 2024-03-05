using EcommerceNetBlazor.Shared.DTOs;

namespace EcommerceNetBlazor.Service.Contracts
{
    public interface IDashboardService
    {
        Task<DashboardDTO> Resume();
    }
}
