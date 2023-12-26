using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using WebApp7.Models.User;
using WebApp7.Repositories;
using WebApp7.Services;
namespace WebApp7.Controllers
{
   [Route("api/v1/[controller]")]
   [ApiController]
   [Produces(MediaTypeNames.Application.Json)]
   public class AuthenticationController : ControllerBase
   {
      public TokenService TokenService { get; }
      public IAuthenticationRepository AuthenticationRepository { get; }

      public AuthenticationController(TokenService tokenService, IAuthenticationRepository authenticationRepository)
      {
         TokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
         AuthenticationRepository = authenticationRepository;
      }

      [HttpGet]
      [Authorize()]
      [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<IActionResult> GetUserAsync()
      {
         try
         {
            var model = await AuthenticationRepository.GetUserByEmailAsync(User?.Identity?.Name);
            if (model is not null)
            {
               return Ok(model);
            }
            return BadRequest();
         }
         catch (Exception)
         {
            throw;
         }
      }


      [HttpPost]
      [AllowAnonymous]
      [ProducesResponseType(typeof(TokenDTO), StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
      {
         try
         {
            if (ModelState.IsValid && await AuthenticationRepository.IsUserByEmailAndPasswordAsync(userLogin))
            {
               return Ok(TokenService.Generate(userLogin));
            }
            return BadRequest();
         }
         catch (Exception)
         {
            throw;
         }
      }
   }
}
