using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PicknPayAspNetCoreWebApi.Models;

namespace PicknPayAspNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _settings;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> settings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _settings = settings.Value;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<Object>PostApplicationUser(ApplicationUserModel model)
        {
            var appUser = new ApplicationUser()
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.Mobile,
                StreetAddress = model.StreetAddress,
                Suburb = model.Suburb,
                City = model.City,
                Password = model.Password,
                PostalCode = model.PostalCode,
                Province = model.Province,
                Email = model.Email,
            };

            try
            {
                var results = await _userManager.CreateAsync(appUser, model.Password);
                return Ok(results);
            }
            catch (Exception exception)
            {

                throw exception ;
            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult>Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new 
                    SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new {token});
            }
            else
            {
                return BadRequest(new { message = "Username or Password is incorrect." });
            }
        }
    }
}