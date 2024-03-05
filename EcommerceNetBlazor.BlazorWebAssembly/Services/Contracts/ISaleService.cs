using EcommerceNetBlazor.Shared.DTOs;

namespace EcommerceNetBlazor.BlazorWebAssembly.Services.Contracts
{
    public interface ISaleService
    {
        Task<ResponseDTO<SaleDTO>> Register(SaleDTO entity);
    }
}
