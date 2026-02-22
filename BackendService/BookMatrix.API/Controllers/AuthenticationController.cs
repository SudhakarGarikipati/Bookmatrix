using Administration.Application.DTOs;
using Administration.Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookMatrix.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthenticationController : Controller
    {
        private readonly IAdministrationAppService _administrationAppService;

        public AuthenticationController(IAdministrationAppService administrationAppService)
        {
            _administrationAppService = administrationAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(SignInDto signInDto)
        {
            try
            {
                await _administrationAppService.RegisterUserAsync(signInDto);
                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                var user = await _administrationAppService.LoginAsync(loginDto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            try
            {
                await _administrationAppService.ChangePasswordAsync(changePasswordDto);
                return Ok("Password changed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
