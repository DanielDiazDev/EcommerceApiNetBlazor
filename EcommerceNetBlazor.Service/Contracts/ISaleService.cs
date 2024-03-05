using EcommerceNetBlazor.Shared.DTOs;

namespace EcommerceNetBlazor.Service.Contracts
{
    public interface ISaleService
    {
        Task<SaleDTO> Register(SaleDTO entity);
    }
}
