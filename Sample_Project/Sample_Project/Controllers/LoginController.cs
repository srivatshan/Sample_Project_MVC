using Sample_Project.Data.Repository.Interface;
using Sample_Project.Filters;
using Sample_Project.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sample_Project.Controllers
{
    public class LoginController : ApiController
    {

        private readonly IUserRepository _userRepository;
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [ValidateModel]
        [HttpGet]
        public async Task<IHttpActionResult> GetToken(LoginModel loginModel)
        {
            var user = _userRepository.GetUseretails(loginModel.UserName, loginModel.Password);
            if (user != null)
            {
                TokenModel Token = CreateToken(user.UserName);
                return Ok(Token);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTokenFromRefreshToken(string refreshToken)
        {
            var user = _userRepository.GetUserByRefreshToken(refreshToken);
            if (user != null)
            {
                TokenModel Token = CreateToken(user);
                return Ok(Token);
            }
            return NotFound();
        }



        private TokenModel CreateToken(string userName)
        {
            DateTime IssuedAt = DateTime.UtcNow;
            DateTime Expires = DateTime.UtcNow.AddMinutes(2);
            var TokenHandler = new JwtSecurityTokenHandler();
            ClaimsIdentity ClaimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userName)
            });

            const string key = "asdfghjkloiuytrewq";
            var SecurityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(key));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(SecurityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);
            var Token = (JwtSecurityToken)TokenHandler.CreateJwtSecurityToken(issuer: "https://localhost:44399", audience: "https://localhost:44399",
                subject: ClaimsIdentity, notBefore: IssuedAt, expires: Expires, signingCredentials: signingCredentials);
            var TokenString = TokenHandler.WriteToken(Token);
            var RefreshToken = GenerateRefreshToken();
            _userRepository.UpdateReferenceToken(userName, RefreshToken);
            return new TokenModel { Token = TokenString, Expires = Expires.ToString(), RefreshToken = RefreshToken };
        }

        private string GenerateRefreshToken()
        {
            RNGCryptoServiceProvider rNGCryptoService = new RNGCryptoServiceProvider();
            byte[] Bytes = new byte[32];
            rNGCryptoService.GetBytes(Bytes);
            var token = Convert.ToBase64String(Bytes);
            return token;
        }
    }

}
