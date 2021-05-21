using ControleFinanceiro.Domain.Entities.Customer;
using ControleFinanceiro.Domain.Services.Contracts;
using ControleFinanceiro.Shared;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControleFinanceiro.Infra.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(Customer customer)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.SecretToken);

            var tokenDescription = new SecurityTokenDescriptor();
            tokenDescription.Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, customer.Email.Address),
                new Claim(ClaimTypes.Sid, customer.Id.ToString()),
                //new Claim(ClaimTypes.Role, user.Role.ToString())
            });
            tokenDescription.Expires = DateTime.UtcNow.AddMinutes(30);
            tokenDescription.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
