using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Livros.Authentication.Models;
using Livros.Authentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Services.Api.Controllers.v2
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class UserController : Controller
    {
        private readonly IJwtFactory _jwtFactory;

        public UserController(IJwtFactory jwtFactory)
        {
            _jwtFactory = jwtFactory;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            if (model.Email != "admin@admin.com" && model.Password != "password")
                return BadRequest("Login ou senha inválidos");

            return Ok(new { Token = await GenerateToken(model) });
        }

        private async Task<string> GenerateToken(LoginDTO dto)
        {
            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, dto.Email));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, dto.Email));

            var jwtToken = await _jwtFactory.GenerateJwtToken(claimsIdentity);

            return jwtToken;
        }
    }
}
