using Microsoft.IdentityModel.Tokens;
using OFM.SellerPortal.Models;
using OFM.SellerPortal.Services.Interfaces;
using OFM.SellerPortal.Shared.Models.Auth.Login;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OFM.SellerPortal.Services
{
    public class AuthService : IAuthService
    {
        private string CreateJWT()
        {
            var secretkey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("THIS IS THE SECRET KEY")); // NOTE: SAME KEY AS USED IN Program.cs FILE
            var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

            var claims = new[] // NOTE: could also use List<Claim> here
			{
                new Claim(ClaimTypes.Name, "Manao Software User"), // NOTE: this will be the "User.Identity.Name" value
				new Claim(JwtRegisteredClaimNames.Sub, "Sub"),
                new Claim(JwtRegisteredClaimNames.Email, "test@manaosoftware.com"),
                new Claim(JwtRegisteredClaimNames.Jti, "USER_ID_123456"), // NOTE: this could a unique ID assigned to the user by a database
                new Claim("canAdd", true.ToString()),
                new Claim("canUpdate", true.ToString()),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var token = new JwtSecurityToken(issuer: "domain.com", audience: "domain.com", claims: claims, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public Task<LoginResponse> Login(LoginRequest request)
        {
            return Task.FromResult(new LoginResponse { UserData = CreateJWT() });
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }
    }
}
