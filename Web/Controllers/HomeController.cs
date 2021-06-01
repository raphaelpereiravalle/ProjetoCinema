using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjetoCinema.Web.Client;
using ProjetoCinema.Web.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ClientService client = new ClientService();

                HomeViewModel painel = new HomeViewModel();

                // Painel com a contagem de filmes 
                painel.totalFilmes = await client.GetAsync<int>(_config["UrlApi"] + "/Filme/contador",
                    User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), null);

                painel.mediaValorIngresso = await client.GetAsync<double>(_config["UrlApi"] + "/Sessao/media",
                    User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), null);

                return View(painel);
            }
            catch (Exception ex)
            {
                return Json(new JsonModel() { success = false, message = ex.Message });
            }
        }
    }
}
