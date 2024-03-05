using EcommerceNetBlazor.Service.Contracts;
using EcommerceNetBlazor.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceNetBlazor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("List/{find?}")]
        public async Task<IActionResult> List(string find = "NA")
        {
            var response = new ResponseDTO<List<ProductDTO>>();

            try
            {
                if (find == "NA") find = "";

                response.IsSuccess = true;
                response.Result = await _productService.List(find);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
        [HttpGet("Catalog/{category}/{find?}")]
        public async Task<IActionResult> Catalog(string category, string find = "NA")
        {
            var response = new ResponseDTO<List<ProductDTO>>();

            try
            {
                if (category.ToLower() == "todos") category = "";
                if (find == "NA") find = "";

                response.IsSuccess = true;
                response.Result = await _productService.Catalog(category, find);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = new ResponseDTO<ProductDTO>();

            try
            {
                response.IsSuccess = true;
                response.Result = await _productService.GetById(id);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ProductDTO productDTO)
        {
            var response = new ResponseDTO<ProductDTO>();

            try
            {
                response.IsSuccess = true;
                response.Result = await _productService.Create(productDTO);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] ProductDTO productDTO)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsSuccess = true;
                response.Result = await _productService.Edit(productDTO);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsSuccess = true;
                response.Result = await _productService.Delete(id);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
    }
}
