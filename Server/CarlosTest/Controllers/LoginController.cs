using CarlosTest.Dtos;
using CarlosTest.Enums;
using CarlosTest.Models;
using CarlosTest.Security;
using CarlosTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarlosTest.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        #region Private properties
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("autenticate")]
        public async Task<IHttpActionResult> AutenticateAsync([FromBody] LoginRequest login)
        {
            if (login == null || login?.Username == null || login?.Username == null)
            {
                HttpResponseMessage errorMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
                errorMessage.Content = new StringContent("Bad Request");
                throw new HttpResponseException(errorMessage);
            }

            var currentUser = await _userService.GetUser(login.Username);

            if (currentUser == null)
            {
                HttpResponseMessage errorMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
                errorMessage.Content = new StringContent("User not found");
                throw new HttpResponseException(errorMessage);
            }

            string loginPassword = HashPassword.ToHashPassword(login.Password);
            bool isCredentialValid = HashPassword.VerifyHashedPassword(currentUser.UserPassword, login.Password);

            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(currentUser);
                return Ok(token);
            }
            else
            {
                HttpResponseMessage errorMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                errorMessage.Content = new StringContent("Invalid credentials");
                throw new HttpResponseException(errorMessage);
            }
        }
       
        [HttpPost]
        [Route("register")]
        public async Task<IHttpActionResult> RegisterAsync([FromBody] UserDto user)
        {
            if (user == null || user?.Email == null || user?.UserPassword == null)
            {
                HttpResponseMessage errorMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
                errorMessage.Content = new StringContent("Bad Request");
                throw new HttpResponseException(errorMessage);
            }
            
            string hashPassword = HashPassword.ToHashPassword(user.UserPassword);
            user.UserPassword = hashPassword;
            user.Type = (int) UserType.User;

            try
            {
                await _userService.RegisterUserAsync(user);
                var token = TokenGenerator.GenerateTokenJwt(user);
                return Ok(token);
            }
            catch(Exception exception) {
                HttpResponseMessage errorMessage = new HttpResponseMessage(HttpStatusCode.Conflict);
                errorMessage.Content = new StringContent(exception.Message);
                throw new HttpResponseException(errorMessage);
            }
        }
        
        #endregion

    }
}
