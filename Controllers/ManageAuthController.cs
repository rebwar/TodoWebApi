using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Dtos;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("api/manageauth")]
    public class ManageAuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ManageAuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]

        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = userDto.UserName, Email = userDto.Email };
                var result = await _userManager.CreateAsync(user, userDto.Password);
                if(result.Succeeded){
                    return Ok(result);
                }
                else{
                    BadRequest();
                }
            }
            
            return BadRequest();
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login(UserLoginDto userLogin){
            var findUser=await _userManager.FindByEmailAsync(userLogin.Email);
            if(findUser !=null){
                var isCorrect=await _userManager.CheckPasswordAsync(findUser,userLogin.Password);
                if(isCorrect){
                    return Ok(findUser);
                }
                else{
                    return NotFound();
                }

            }
            return NotFound();
        }

    }
}