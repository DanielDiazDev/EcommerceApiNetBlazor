using EcommerceNetBlazor.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceNetBlazor.Service.Contracts
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> List(string find);
        Task<CategoryDTO> GetById(int id);
        Task<CategoryDTO> Create(CategoryDTO entity);
        Task<bool> Edit(CategoryDTO entity);
        Task<bool> Delete(int id);
    }
}
