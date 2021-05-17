using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjetoCinema.Domain.Model;
using ProjetoCinema.Web.Client;
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

                DadosSessao resultado = await client.GetAsync<DadosSessao>(_config["UrlApi"] + "/Sessao/listar-sessao/",
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
                    Sessao Sessao = new Sessao();

                    return View(Sessao);
                }
                else
                {
                    ClientService client = new ClientService();

                    Sessao resultado = await client.GetAsync<Sessao>(_config["UrlApi"] + "/Sessao/sessao?IdSessao="
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
        public async Task<JsonResult> IncluirSessao(Sessao sessao)
        {
            try
            {
                try
                {
                    ClientService client = new ClientService();

                    sessao.IdUsuario = User.Claims.Where(s => s.Type == "ID").Select(s => s.Value).First();

                    Notificacao resultado = await client.PostAsync<Sessao>(_config["UrlApi"] + "/Sessao/Sessao/"
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<JsonResult> EditarSessao(Sessao sessao)
        {
            try
            {
                try
                {
                    ClientService client = new ClientService();

                    sessao.IdUsuario = User.Claims.Where(s => s.Type == "ID").Select(s => s.Value).First();

                    Notificacao resultado = await client.PutAsync<Sessao>(_config["UrlApi"] + "/Sessao/sessao/",
                    User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), sessao);

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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ExcluirSessao(string cod)
        {
            try
            {
                ClientService client = new ClientService();

                Sessao resultado = await client.GetAsync<Sessao>(_config["UrlApi"] + "/Sessao/sessao?IdSessao="
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
                try
                {
                    ClientService client = new ClientService();

                    Notificacao resultado = await client.DeleteAsync<Notificacao>(_config["UrlApi"] + "/Sessao/sessao/?IdSessao="
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
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GridSessao()
        {
            try
            {
                ClientService client = new ClientService();

                DadosSessao resultado = await client.GetAsync<DadosSessao>(_config["UrlApi"] + "/Sessao/listar-sessao/"
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
