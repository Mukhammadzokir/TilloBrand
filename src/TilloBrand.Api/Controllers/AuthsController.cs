using Microsoft.AspNetCore.Mvc;
using TilloBrand.Service.DTOs.Logins;
using TilloBrand.Service.Interfaces;

namespace TilloBrand.Api.Controllers
{
    public class AuthsController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> PostAsync(LoginDto dto)
        {
            var token = await this._authService.AuthenticateAsync(dto);
            return Ok(token);
        }
    }
}
