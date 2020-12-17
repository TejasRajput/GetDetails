using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using SystemInfoCommon.Interface;
using SystemInfoCommon.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace SystemInfoService
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly AppSettings _appSettings;

        private readonly List<User> _users = new List<User>
        {
            new User
            {
                UserId = 1,
                FirstName = "Tejas",
                LastName = "Rajput",
                UserName = "TejasRajput",
                Password = "TEJAS2604"
            }
        };

        public AuthenticateService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }

        public User Authenticate(string userName, string password)
        {
            var user = _users.SingleOrDefault(x => x.UserName == userName && x.Password == password);


            if (user == null) return null;

            var tokenHandeler = new JwtSecurityTokenHandler();
            var Key = Encoding.UTF32.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V3.1")
                }),
                Expires = DateTime.UtcNow.AddMinutes(2),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandeler.CreateToken(tokenDescriptor);
            user.Token = tokenHandeler.WriteToken(token);

            user.Password = null;
            return user;
        }
    }
}