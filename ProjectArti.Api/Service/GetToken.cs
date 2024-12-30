using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectArti.Api.Service
{
    public class GetToken(JwtOptions jwtOptions) : IGetToken
    {

        public string CreateToken(string token,string role)
        {
            var Key = Encoding.ASCII.GetBytes(jwtOptions.SecretKey);   
            var TokenHandler = new JwtSecurityTokenHandler();
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                { 
                    new (ClaimTypes.Name, token),
                    new (ClaimTypes.Role, role),
                }
                ),
                Issuer = jwtOptions.Issuer,
                Audience=jwtOptions.Audiences,
                Expires=DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };
           var Token = TokenHandler.CreateToken(TokenDescriptor);
          return  TokenHandler.WriteToken(Token);

        }
    }

}

