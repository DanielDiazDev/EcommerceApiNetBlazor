using AutoMapper;
using EcommerceNetBlazor.Data.Repositories.Contracts;
using EcommerceNetBlazor.Model;
using EcommerceNetBlazor.Service.Contracts;
using EcommerceNetBlazor.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceNetBlazor.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Create(CategoryDTO entity)
        {
            try
            {
                var category = _mapper.Map<Category>(entity);
                var categoryCreated = await _unitOfWork.CategoryRepository.Create(category);
                if(categoryCreated.Id != 0)
                {
                    return _mapper.Map<CategoryDTO>(categoryCreated);
                }
                else
                {
                    throw new TaskCanceledException("No se pudo crear");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var consult = _unitOfWork.CategoryRepository.Consult(c => c.Id == id);
                var categoryConsulted = await consult.FirstOrDefaultAsync();
                if (categoryConsulted != null)
                {
                    var response = await _unitOfWork.CategoryRepository.Delete(categoryConsulted);
                    if (!response)
                    {
                        throw new TaskCanceledException("No se pudo eliminar");
                    }
                    return response;
                }
                else
                {
                    throw new TaskCanceledException("No se econtraron resultados");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<bool> Edit(CategoryDTO entity)
        {
            try
            {
                var consult = _unitOfWork.CategoryRepository.Consult(c => c.Id == entity.Id);
                var categoryConsulted = await consult.FirstOrDefaultAsync();
                if (categoryConsulted != null)
                {
                    categoryConsulted.Name = entity.Name;
                    var response = await _unitOfWork.CategoryRepository.Edit(categoryConsulted);
                    if (!response)
                    {
                        throw new TaskCanceledException("No se pudo editar");
                    }
                    return response;
                }
                else
                {
                    throw new TaskCanceledException("No se econtraron resultados");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            try
            {
                var consult = _unitOfWork.CategoryRepository.Consult(c => c.Id == id);
                var categoryConsulted = await consult.FirstOrDefaultAsync();
                if(categoryConsulted != null)
                {
                    return _mapper.Map<CategoryDTO>(categoryConsulted);
                }
                else
                {
                    throw new TaskCanceledException("No se econtraron coincidencias");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CategoryDTO>> List(string find)
        {
            try
            {
                var consult = _unitOfWork.CategoryRepository.Consult(c => 
                c.Name!.ToLower().Contains(find.ToLower()));
                List<CategoryDTO> list = _mapper.Map<List<CategoryDTO>>(await consult.ToListAsync());
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
