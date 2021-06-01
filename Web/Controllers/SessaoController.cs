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
    public class SessaoController : Controller
    {
        private readonly IConfiguration _config;

        public SessaoController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                ClientService client = new ClientService();

                DadosSessaoViewModel resultado = await client.GetAsync<DadosSessaoViewModel>(_config["UrlApi"] + "/Sessao/listar-sessao/",
                User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), null);

                return View(resultado.Resultado);
            }
            catch (Exception ex)
            {
                return Json(new JsonModel() { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ManterSessao(string cod)
        {
            try
            {
                if (string.IsNullOrEmpty(cod))
                {
                    SessaoViewModel Sessao = new SessaoViewModel();

                    return View(Sessao);
                }
                else
                {
                    ClientService client = new ClientService();

                    SessaoViewModel resultado = await client.GetAsync<SessaoViewModel>(_config["UrlApi"] + "/Sessao/sessao?IdSessao="
                        , User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), cod);

                    return View(resultado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> IncluirSessao(SessaoViewModel sessao)
        {
            try
            {
                ClientService client = new ClientService();

                sessao.IdUsuario = User.Claims.Where(s => s.Type == "ID").Select(s => s.Value).First();

                NotificacaoViewModel resultado = await client.PostAsync<SessaoViewModel>(_config["UrlApi"] + "/Sessao/Sessao/"
                    , User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), sessao);

                if (resultado.Erro)
                {
                    return Json(new JsonModel() { success = false, result = resultado.Resultado, message = resultado.Msg });
                }

                return Json(new JsonModel() { success = true, result = resultado, message = resultado.Msg });
            }
            catch (Exception ex)
            {
                return Json(new JsonModel() { success = false, message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<JsonResult> EditarSessao(SessaoViewModel sessao)
        {
            try
            {
                ClientService client = new ClientService();

                sessao.IdUsuario = User.Claims.Where(s => s.Type == "ID").Select(s => s.Value).First();

                NotificacaoViewModel resultado = await client.PutAsync<SessaoViewModel>(_config["UrlApi"] + "/Sessao/sessao/"
                    , User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), sessao);

                if (resultado.Erro)
                {
                    return Json(new JsonModel() { success = false, result = resultado.Resultado, message = resultado.Msg });
                }

                return Json(new JsonModel() { success = true, result = resultado, message = resultado.Msg });
            }
            catch (Exception e)
            {
                return Json(new JsonModel() { success = false, message = e.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ExcluirSessao(string cod)
        {
            try
            {
                ClientService client = new ClientService();

                SessaoViewModel resultado = await client.GetAsync<SessaoViewModel>(_config["UrlApi"] + "/Sessao/sessao?IdSessao="
                    , User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), cod);

                return View(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteSessao(string cod)
        {
            try
            {
                ClientService client = new ClientService();

                NotificacaoViewModel resultado = await client.DeleteAsync<NotificacaoViewModel>(_config["UrlApi"] + "/Sessao/sessao/?IdSessao="
                    , User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), cod);

                if (resultado.Erro)
                {
                    return Json(new JsonModel() { success = false, result = resultado.Resultado, message = resultado.Msg });
                }

                return Json(new JsonModel() { success = true, result = resultado, message = resultado.Msg });
            }
            catch (Exception ex)
            {
                return Json(new JsonModel() { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GridSessao()
        {
            try
            {
                ClientService client = new ClientService();

                DadosSessaoViewModel resultado = await client.GetAsync<DadosSessaoViewModel>(_config["UrlApi"] + "/Sessao/listar-sessao/"
                    , User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), null);

                return PartialView("_GridSessao", resultado.Resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
