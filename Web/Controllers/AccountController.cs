using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjetoCinema.Domain.Model.Identity.AccountViewModels;
using ProjetoCinema.Domain.Token.Model;
using ProjetoCinema.Web.Client;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjetoCinema.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IConfiguration _config;

        public AccountController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [Route("account/login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                AccessCredentials accessCredentials = new AccessCredentials();
                accessCredentials.Email = model.Email;
                accessCredentials.Password = model.Password;
                accessCredentials.GrantType = "password";
                ClientService client = new ClientService();
                Token resultado = await client.PostAsyncLogin<AccessCredentials>(_config["UrlApi"] + "/Login/login/", accessCredentials);
                if (resultado.Authenticated)
                {
                    // Adiciona o cookie na pagina
                    AddCookie(resultado, model.Email);
                    if (returnUrl == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(returnUrl);
                }
            }
            return View(model);
        }

        // Faz o Logout e elimina o cookie
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        // Adiciona o Cookie na pagina tendo o mesmo tempo de expeiração do Token
        private void AddCookie(Token token, string email)
        {
            var claims = new List<Claim>
            {
                new Claim("ID", token.Id),
                new Claim("Name", token.Name),
                new Claim(ClaimTypes.Name, "ADM"),
                new Claim(ClaimTypes.Authentication, token.Authenticated.ToString()),
                new Claim("AccessToken", token.AccessToken),
                new Claim("Email", email),
                new Claim("Expiration", token.Expiration),
            };

            var userIdentity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            HttpContext.SignInAsync(principal);
        }
    }
}