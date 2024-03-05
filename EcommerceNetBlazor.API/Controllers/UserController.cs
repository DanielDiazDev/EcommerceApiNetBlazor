using EcommerceNetBlazor.Service.Contracts;
using EcommerceNetBlazor.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceNetBlazor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UserDTO userDTO)
        {
            var response = new ResponseDTO<UserDTO>();

            try
            {
                response.IsSuccess = true;
                response.Result = await _userService.Create(userDTO);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
        [HttpGet("List/{role}/{find?}")]
        public async Task<IActionResult> List(string role, string find = "NA")
        {
            var response = new ResponseDTO<List<UserDTO>>();

            try
            {
                if (find == "NA") find = "";

                response.IsSuccess = true;
                response.Result = await _userService.List(role, find);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }


        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = new ResponseDTO<UserDTO>();

            try
            {
                response.IsSuccess = true;
                response.Result = await _userService.GetById(id);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
        [HttpPost("Authorization")]
        public async Task<IActionResult> Authorization([FromBody] LoginDTO loginDTO)
        {
            var response = new ResponseDTO<SessionDTO>();

            try
            {
                response.IsSuccess = true;
                response.Result = await _userService.Authorization(loginDTO);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] UserDTO userDTO)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsSuccess = true;
                response.Result = await _userService.Edit(userDTO);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsSuccess = true;
                response.Result = await _userService.Delete(id);

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
