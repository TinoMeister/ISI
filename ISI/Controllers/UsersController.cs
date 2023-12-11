using ISI.Data;
using ISI.Models;
using ISI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserRepositoryDB _repository;
        private readonly JwtService _jwtService;

        public UsersController(IConfiguration configuration, JwtService jwtService)
        {
            _config = configuration;
            _jwtService = jwtService;
            _repository = new UserRepositoryDB(_config["ConnectionStrings:DbConnection"]!);
        }

        /// <summary>
        /// This Method Authenticate the User
        /// </summary>
        /// <param name="request">Authentication Request</param>
        /// <returns>Token</returns>
        [HttpPost("Login")]
        public ActionResult<AuthResponse> Authenticate(AuthRequest request)
        {
            // Get user by email
            User? managedUser = _repository.FindByEmail(request.Email);

            // Verify if is null
            if (managedUser is null) return BadRequest("Bad credentials");

            // Verify password if correct
            if (managedUser.Password != request.Password) return BadRequest("Bad credentials");

            // Generate an Token
            var token = _jwtService.CreateToken(managedUser);

            // Return Token
            return Ok(token);
        }

        /// <summary>
        /// This Method Creates a new User
        /// </summary>
        /// <param name="request">Registration Request</param>
        /// <returns>Token</returns>
        [HttpPost("Register")]
        public ActionResult<AuthResponse> PostUser(RegistrationRequest request)
        {
            // If the Email alredy exists return BadRequest
            if (_repository.FindByEmail(request.Email) is not null) return BadRequest();

            // Create a new user with the username and email
            // If something went wrong return BadRequest
            if (!_repository.CreateUser(request)) return BadRequest();

            // Get user with all the data necessary
            User? tempUser = _repository.FindByEmail(request.Email);

            // Verify if the user is null
            if (tempUser is null) return NotFound();

            // Generate Token
            AuthResponse token = _jwtService.CreateToken(tempUser);

            // Return Token
            return Ok(token);
        }
    }
}
