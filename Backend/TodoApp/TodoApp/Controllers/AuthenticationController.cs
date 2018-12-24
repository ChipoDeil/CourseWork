using Microsoft.AspNetCore.Mvc;
using TodoApp.Models.AuthenticationModels;
using TodoApp.Security;
using TodoAppLibrary.UserContext;

namespace TodoApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        /// <summary>
        /// Регистрация в системе
        /// </summary>
        [HttpPost]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public IActionResult Register([FromBody] RegistrateRequestModel model)
        {
            _userFacade.CreateNewUser(model.Username, model.Password, 
                model.Email, model.DateOfBirth);

            return Ok();
        }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        [HttpPut]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(LoginResponseModel), 200)]
        [ProducesResponseType(400)]
        public IActionResult Login([FromBody] LoginRequestModel model)
        {
            if (!_userFacade.DoesUserExists(model.Email, model.Password)) return Unauthorized();

            var currentUserView = _userFacade.GerUserInfoByEmail(model.Email);
            var result = new LoginResponseModel(_jwtIssuer.IssueJwt(Claims.Roles.User,
                currentUserView.Identifier.Id), currentUserView.Username);

            return Ok(result);

        }

        private readonly IJwtIssuer _jwtIssuer;
        private readonly IUserFacade _userFacade;

        public AuthenticationController(IJwtIssuer jwtIssuer, IUserFacade userFacade)
        {
            _jwtIssuer = jwtIssuer;
            _userFacade = userFacade;
        }
    }
}