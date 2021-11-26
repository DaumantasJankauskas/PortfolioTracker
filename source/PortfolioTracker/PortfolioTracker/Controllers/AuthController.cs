using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioTracker.Auth;
using PortfolioTracker.Auth.Model;
using PortfolioTracker.Data.Dtos.Auth;
using System.Threading.Tasks;

namespace PortfolioTracker.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api")]
    public class AuthController : Controller
    {
        private readonly UserManager<PortfolioUser> _userManager;
        private readonly IMapper _mapper;
        private ITokenManager _tokenManager;

        public AuthController(UserManager<PortfolioUser> userManager, IMapper mapper, ITokenManager tokenManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenManager = tokenManager;
        }



        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            var user = await _userManager.FindByIdAsync(registerUserDto.UserName);
            if (user != null)
                return BadRequest("Invalid request");

            var newUser = new PortfolioUser
            {
                Email = registerUserDto.Email,
                UserName = registerUserDto.UserName
            };
            var createUserResult = await _userManager.CreateAsync(newUser, registerUserDto.Password);
            if (!createUserResult.Succeeded)
                return BadRequest("Couldnt create user");

            await _userManager.AddToRoleAsync(newUser, PortfolioUserRoles.SimpleUser);
            return CreatedAtAction(nameof(Register), _mapper.Map<UserDto>(newUser));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null)
            {
                return BadRequest("Username or password is invalid");
            }
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isPasswordValid)
                return BadRequest("Username or password is invalid");

            var accessToken = await _tokenManager.CreateAccessTokenAsync(user);

            return Ok(new SuccessfulLoginResponseDto(accessToken));
        }
    }
}
