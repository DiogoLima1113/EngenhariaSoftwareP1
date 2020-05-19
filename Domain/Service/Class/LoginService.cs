using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Repository.Interface;
using EngenhariaSoftware.Domain.Service.Interface;
using Microsoft.IdentityModel.Tokens;

namespace EngenhariaSoftware.Domain.Service.Class
{
    public class LoginService : ILoginService
    {
        private IUsersDbRepository _usersRepository;
        private TokenConfigurations _tokenConfigurations;
        private SigningConfigurations _signingConfigurations;

        public LoginService(
            IUsersDbRepository usersRepository,
            TokenConfigurations tokenConfiguration,
            SigningConfigurations signingConfiguration)
        {
            _usersRepository = usersRepository;
            _tokenConfigurations = tokenConfiguration;
            _signingConfigurations = signingConfiguration;
        }
        public LoginResponse GenerateToken(User user)
        {
            bool validCredentials = false;
            UserType? tipoUsuario = null;
            
            if (user != null && !String.IsNullOrWhiteSpace(user.Id))
            {
                var baseUser = _usersRepository.Find(user.Id);
                validCredentials = (baseUser != null &&
                    user.Id == baseUser.Id &&
                    user.AccessKey == baseUser.AccessKey);
                    tipoUsuario = baseUser.Tipo;
            }
            
            if (validCredentials)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Id, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Id)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _tokenConfigurations.Issuer,
                    Audience = _tokenConfigurations.Audience,
                    SigningCredentials = _signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new LoginResponse(
                    true,
                    "OK",
                    token,
                    dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    tipoUsuario);
            }
            else
            {
                return new LoginResponse(false,"Authentication Error");
            }
        }
    }
}