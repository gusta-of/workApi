using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using workApi.ExtensionMethods;
using workApi.Helpers;
using workApi.Interfaces.ISercive;
using workApi.Model;

namespace workApi.Services
{
    public class OperadorService : IService<Operador>
    {
        private readonly AppSettings _appSettings;
        private readonly AppDbContext _appDbContext;

        /* Lista apenas para teste */
        private List<Operador> _operadores = new List<Operador>()
        {
            new Operador() { Id = 1, UserName = "Teste1", Email="Teste1", Senha="Teste1"},
            new Operador() { Id = 1, UserName = "Teste2", Email="Teste2", Senha="Teste2"},
            new Operador() { Id = 1, UserName = "Teste3", Email="Teste3", Senha="Teste3"},
        };

        public OperadorService(IOptions<AppSettings> appSettings,
            IOptions<AppDbContext> appDbContext)
        {
            _appSettings = appSettings.Value;
            _appDbContext = appDbContext.Value;
        }

        public Operador Autentique(string username, string senha)
        {
            var operador = _operadores.SingleOrDefault(x => x.UserName == username && x.Senha == senha);

            if (operador == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, operador.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            operador.Token = tokenHandler.WriteToken(token);

            return operador.ClearPassword();
        }

        public IEnumerable<Operador> GetAll()
        {
            return _operadores.ClearAllPassword();
        }

        public Operador GetId(long id)
        {
            throw new NotImplementedException();
        }
    }
}
