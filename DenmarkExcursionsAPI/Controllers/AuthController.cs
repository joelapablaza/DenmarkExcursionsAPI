using DenmarkExcursionsAPI.Models.DTO;
using DenmarkExcursionsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DenmarkExcursionsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            // Implicit validation incoming request with Fluent
            // Check if User is authenticated
            var user = await _userRepository.AuthenticateAsync(loginRequest.UserName, loginRequest.Password);
        
            if (user != null)
            {
                // Generate JWT Token
                var token = await _tokenHandler.CreateTokenAsync(user);
                return Ok(token);
            }

            return BadRequest("Username or Password is incorrect");
        }
    }
}
