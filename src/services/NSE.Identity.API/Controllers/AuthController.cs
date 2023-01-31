using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSE.Identity.API.Dtos;

namespace NSE.Identity.API.Controllers
{
    [Route("api/identity")]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("new-account")]
        public async Task<ActionResult> Register(UserRegistrationDto userRegistrationDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = new IdentityUser
            {
                UserName = userRegistrationDto.Email,
                Email = userRegistrationDto.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRegistrationDto.Password);

            if (!result.Succeeded) return BadRequest();

            await _signInManager.SignInAsync(user, false);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginDto userLoginDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _signInManager.PasswordSignInAsync(userLoginDto.Email, userLoginDto.Password, false, true);

            if (!result.Succeeded) return BadRequest();

            return Ok();
        }
    }
}
