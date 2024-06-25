using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyNotepad.Classes
{
    public class TokenAuthentication
    {
        private IConfiguration _configuration { get; set; }

        public TokenAuthentication(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string gerarToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim("codigo", usuario.codigo.ToString()!),
                new Claim("userName", usuario.userName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var chaveSecreta = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]));
            var credenciais = new SigningCredentials(chaveSecreta, SecurityAlgorithms.HmacSha256);
            var expiracao = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(claims: claims, expires: expiracao, signingCredentials: credenciais);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
