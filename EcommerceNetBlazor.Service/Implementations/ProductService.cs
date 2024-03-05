using AutoMapper;
using EcommerceNetBlazor.Data.Repositories.Contracts;
using EcommerceNetBlazor.Model;
using EcommerceNetBlazor.Service.Contracts;
using EcommerceNetBlazor.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EcommerceNetBlazor.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> Catalog(string category, string find)
        {
            try
            {
                var consult = _unitOfWork.ProductRepository.Consult(p =>
                p.Name.ToLower().Contains(find.ToLower()) && 
                p.Category.Name.ToLower().Contains(category.ToLower()));
                var list = _mapper.Map<List<ProductDTO>>(await consult.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            }
        public async Task<ProductDTO> Create(ProductDTO entity)
        {
            try
            {
                var product = _mapper.Map<Product>(entity);
                var productCreated = await _unitOfWork.ProductRepository.Create(product);

                if (productCreated.Id != 0)
                    return _mapper.Map<ProductDTO>(productCreated);
                else
                    throw new TaskCanceledException("No se pudo crear");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var consult = _unitOfWork.ProductRepository.Consult(p => p.Id == id);
                var product = await consult.FirstOrDefaultAsync();

                if (product != null)
                {
                    var respuesta = await _unitOfWork.ProductRepository.Delete(product);
                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo eliminar");

                    return respuesta;
                }
                else
                    throw new TaskCanceledException("No se econtraron resultados");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Edit(ProductDTO entity)
        {
            try
            {
                var consult = _unitOfWork.ProductRepository.Consult(p => p.Id == entity.Id);
                var product = await consult.FirstOrDefaultAsync();

                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Description = entity.Description;
                    product.CategoryId = entity.CategoryId;
                    product.Price = entity.Price;
                    product.PriceOffer = entity.PriceOffer;
                    product.Quantity = entity.Quantity;
                    product.Image = entity.Image;


                    var respuesta = await _unitOfWork.ProductRepository.Edit(product);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo editar");
                    return respuesta;
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

        public async Task<ProductDTO> GetById(int id)
        {
            try
            {
                var consult = _unitOfWork.ProductRepository.Consult(p => p.Id == id);
                consult = consult.Include(c => c.Category);
                var product = await consult.FirstOrDefaultAsync();


                if (product != null)
                    return _mapper.Map<ProductDTO>(product);
                else
                    throw new TaskCanceledException("No se econtraron coincidencias");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductDTO>> List(string find)
        {
            try
            {
                var consulta = _unitOfWork.ProductRepository.Consult(p =>
                p.Name.ToLower().Contains(find.ToLower())
                );

                consulta = consulta.Include(c => c.Category);

               var list = _mapper.Map<List<ProductDTO>>(await consulta.ToListAsync());
                return list;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
