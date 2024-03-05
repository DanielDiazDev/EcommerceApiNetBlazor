using EcommerceNetBlazor.Shared.DTOs;

namespace EcommerceNetBlazor.Service.Contracts
{
    public interface IProductService
    {
        Task<List<ProductDTO>> List(string find);
        Task<List<ProductDTO>> Catalog(string category, string find);
        Task<ProductDTO> GetById (int id);
        Task<ProductDTO> Create(ProductDTO entity);
        Task<bool> Edit(ProductDTO entity);
        Task<bool> Delete(int id);
    }
}
