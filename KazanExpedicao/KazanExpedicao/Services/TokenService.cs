using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KazanExpedicao.Models;
using KazanExpedicao.ViewModels;

namespace KazanExpedicao.Services
{
    public class TokenService
    {
        public static TokenVM GenerateToken(UsuarioModel usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(/*Configuracoes.Secret*/ "csdfdsfasdwsgwes");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Role, usuario.Funcao)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenVM = new TokenVM();
            tokenVM.Token = tokenHandler.WriteToken(token);
            tokenVM.DataExpiracaoToken = (DateTime)tokenDescriptor.Expires;
            return tokenVM;
        }
    }
}
