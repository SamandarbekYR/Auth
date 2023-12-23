using Auth.Entity.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.Services.TokenService
{
    public class Token
    {
        public string GetToken(User user)
        {
            var identityClaims = new Claim[]
       {
            new Claim ("Id", user.Id.ToString()),
            new Claim ("Name", user.Name),
            new Claim (ClaimTypes.Role, user.Role.ToString()),
       };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("23f926fb-dcd2-49f4-8fe2-992aac18f08f"));
            var keyCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                issuer: "http://DemoProject.uz",
                audience: "DemoProject",
                claims: identityClaims,
                expires: DateTime.UtcNow.AddHours(5).AddDays(1),
                signingCredentials: keyCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
