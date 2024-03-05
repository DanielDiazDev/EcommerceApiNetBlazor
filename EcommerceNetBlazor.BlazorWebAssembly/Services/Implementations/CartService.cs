using Blazored.LocalStorage;
using Blazored.Toast.Services;
using EcommerceNetBlazor.BlazorWebAssembly.Services.Contracts;
using EcommerceNetBlazor.Shared.DTOs;

namespace EcommerceNetBlazor.BlazorWebAssembly.Services.Implementations
{
    public class CartService : ICartService
    {
        private ILocalStorageService _localStorageService;
        private ISyncLocalStorageService _syncLocalStorageService;
        private IToastService _toastService;

        public CartService(ILocalStorageService localStorageService, ISyncLocalStorageService syncLocalStorageService, IToastService toastService)
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService;
            _toastService = toastService;
        }

        public event Action ShowItems;

        public async Task AddCart(CartDTO entity)
        {
            try
            {
                var cart = await _localStorageService.GetItemAsync<List<CartDTO>>("cart");
                if(cart == null)
                {
                    cart = new List<CartDTO>();
                }
                var found = cart.FirstOrDefault(c => c.Product.Id == entity.Product.Id);
                if(found != null)
                {
                    cart.Remove(found);
                }
                cart.Add(entity);
                await _localStorageService.SetItemAsync("cart", cart);
                if (found != null)
                {
                    _toastService.ShowSuccess("Producto fue actualizado en carrito");
                }
                else
                {
                    _toastService.ShowSuccess("Producto fue agregado al carrito");
                }

                ShowItems.Invoke();
            }
            catch
            {
                _toastService.ShowError("No se pudo agreagar al carrito");
            }
        }

        public async Task ClearCart()
        {
            await _localStorageService.RemoveItemAsync("cart");
            ShowItems.Invoke();
        }

        public async Task DeleteCart(int productId)
        {
            try
            {
                var cart = await _localStorageService.GetItemAsync<List<CartDTO>>("cart");
                if(cart != null)
                {
                    var element = cart.FirstOrDefault(c => c.Product.Id == productId);
                    if(element != null)
                    {
                        cart.Remove(element);
                        await _localStorageService.SetItemAsync("cart", cart);
                        ShowItems.Invoke();
                    }
                }
            }
            catch
            {
                _toastService.ShowError("Hubo un error");
            }
        }

        public async Task<List<CartDTO>> GetCart()
        {
            var cart = await _localStorageService.GetItemAsync<List<CartDTO>>("cart");
            if(cart == null)
            {
                cart = new List<CartDTO>();
            }
            return cart;
        }

        public int QuantityProducts()
        {
            var cart =  _syncLocalStorageService.GetItem<List<CartDTO>>("cart");
            return cart == null ? 0 : cart.Count();
        }
    }
}
