using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using WebApp7.Models.User;
using WebApp7.Repositories;
namespace WebApp7.Controllers
{
   [Route("api/v1/[controller]")]
   [ApiController]
   [Authorize()]
   [Produces(MediaTypeNames.Application.Json)]
   public class UsersController : ControllerBase
   {
      public IUsersRepository UsersRepository { get; }

      public UsersController(IUsersRepository usersRepository)
      {
         UsersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
      }

      [HttpGet]
      [ProducesResponseType(typeof(List<UserDTO>), StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult> UsersGet()
      {
         return Ok(await UsersRepository.GetAllAsync());
      }

      [HttpPost]
      [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult> UserCreate([FromBody] UserCreate userCreate)
      {
         try
         {
            if (ModelState.IsValid)
            {
               UserDTO? userDTO = await UsersRepository.CreateAsync(userCreate);
               if (userDTO != null)
               {
                  return CreatedAtAction(nameof(UsersGet), userDTO);
               }
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
