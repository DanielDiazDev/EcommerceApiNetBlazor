using EcommerceNetBlazor.Service.Contracts;
using EcommerceNetBlazor.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceNetBlazor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] SaleDTO saleDTO)
        {
            var response = new ResponseDTO<SaleDTO>();

            try
            {
                response.IsSuccess = true;
                response.Result = await _saleService.Register(saleDTO);

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
