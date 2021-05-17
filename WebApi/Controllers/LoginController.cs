using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjetoCinema.Core.Security;
using ProjetoCinema.Domain.Model;
using ProjetoCinema.Domain.Token.Model;

namespace ProjetoCinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [Route("login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login(
           [FromBody] AccessCredentials credenciais,
           [FromServices] UserManager<ApplicationUser> userManager,
           [FromServices] SignInManager<ApplicationUser> signInManager,
           [FromServices] SigningConfigurations signingConfigurations,
           [FromServices] TokenConfigurations tokenConfigurations)
        {

            bool credenciaisValidas = false;
            if (credenciais != null && !String.IsNullOrWhiteSpace(credenciais.Email))
            {
                try
                {
                    // Verifica a existência do usuário nas tabelas do ASP.NET Core Identity
                    var userIdentity = userManager.FindByNameAsync(credenciais.Email).Result;

                    if (userIdentity != null)
                    {
                        // Efetua o login com base no Id do usuário e sua senha
                        var resultadoLogin = signInManager
                            .CheckPasswordSignInAsync(userIdentity, credenciais.Password, false)
                            .Result;
                        if (resultadoLogin.Succeeded)
                        {
                            // Verifica se o usuário em questão possui a role App
                            credenciaisValidas = userManager.IsInRoleAsync(
                                userIdentity, Roles.ROLE_APP).Result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            if (credenciaisValidas)
            {
                Token resultado = await GenerateTokenAsync(
                    credenciais.Email, signingConfigurations,
                    tokenConfigurations, credenciais.RefreshToken, userManager);

                return resultado;
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        private async Task<Token> GenerateTokenAsync(string email,
            SigningConfigurations signingConfigurations,
            TokenConfigurations tokenConfigurations,
            string RefreshToken, UserManager<ApplicationUser> userManager)
        {
            try
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(email, "Login"),
                    new[] {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Email, email)
                    }
                );
                var user = userManager.FindByNameAsync(email).Result;
                identity.AddClaims(await userManager.GetClaimsAsync(user));

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao + TimeSpan.FromMinutes(tokenConfigurations.ValidForMinutes);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Subject = identity,
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                Token resultado = new Token()
                {
                    Id = user.Id,
                    Name = user.Nome,
                    Authenticated = true,
                    Created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    AccessToken = token
                };

                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}