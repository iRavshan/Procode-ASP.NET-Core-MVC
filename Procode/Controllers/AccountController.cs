using Entities.Configuration;
using Entities.DTO.Requests;
using Entities.DTO.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Procode.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        private readonly JwtConfig jwtConfig;

        public BinaryReader JwtRegisteredClaims { get; private set; }

        public AccountController(UserManager<IdentityUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            this.userManager = userManager;
            this.jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await userManager.FindByEmailAsync(user.Email);

                if(existingUser != null)
                {
                    return BadRequest(new RegistrationResponses()
                    {
                        Errors = new List<string> { "Email allaqachon ro'yxatga olingan" },
                        Succes = false,
                    });
                }

                var newUser = new IdentityUser() { Email = user.Email, UserName = user.Email.Substring(0, user.Email.IndexOf("@")) };

                var isCreated = await userManager.CreateAsync(newUser, user.Password);

                if (isCreated.Succeeded)
                {
                    GenerateJwtToken(newUser);

                    return View("Index");
                }
                else
                {
                    return BadRequest(new RegistrationResponses()
                    {
                        Errors = isCreated.Errors.Select(w => w.Description).ToList(),
                        Succes = false,
                    });
                }
            }

            return BadRequest(new RegistrationResponses()
            {
                Errors = new List<string> { "Invalid payload" },
                Succes = false,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await userManager.FindByEmailAsync(user.Email);

                if(existingUser == null)
                {
                    return BadRequest(new RegistrationResponses()
                    {
                        Errors = new List<string> { "Ushbu email ro'yxatga olinmagan" },
                        Succes = false,
                    });
                }

                var isCorrect = await userManager.CheckPasswordAsync(existingUser, user.Password);

                var jwtToken = GenerateJwtToken(existingUser);

                return View("~/Views/Home/Blog");

            }

            return BadRequest(new RegistrationResponses()
            {
                Errors = new List<string> { "Invalid payload" },
                Succes = false,
            });
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}
