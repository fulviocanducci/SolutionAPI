using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp7.Models;
using WebApp7.Services;

namespace WebApp7.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class AuthenticationController : ControllerBase
   {
      public TokenService TokenService { get; }

      public AuthenticationController(TokenService tokenService)
      {
         TokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
      }

      [HttpGet]
      [Authorize()]
      public IActionResult GetUser()
      {
         return Ok(new User { Email = User?.Identity?.Name ?? "" });
      }


      [HttpPost]
      [AllowAnonymous]
      public IActionResult Login([FromBody] User user)
      {
         return Ok(TokenService.Generate(new User { Email = "dias.fulvio@gmail.com", Password = "lolikujadfal"}));
      }
   }
}
