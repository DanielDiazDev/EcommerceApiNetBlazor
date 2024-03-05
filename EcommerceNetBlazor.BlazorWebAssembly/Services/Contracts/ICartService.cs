using EcommerceNetBlazor.Shared.DTOs;

namespace EcommerceNetBlazor.BlazorWebAssembly.Services.Contracts
{
    public interface ICartService
    {
        event Action ShowItems;

        int QuantityProducts();
        Task AddCart(CartDTO entity);
        Task DeleteCart(int productId);
        Task<List<CartDTO>> GetCart();
        Task ClearCart();
    }
}
