using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjetoCinema.Domain.Model;
using ProjetoCinema.Web.Client;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCinema.Web.Controllers
{
    [Authorize]
    public class FilmeController : Controller
    {
        private readonly IConfiguration _config;

        public FilmeController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                ClientService client = new ClientService();

                DadosFilme resultado = await client.GetAsync<DadosFilme>(_config["UrlApi"] + "/Filme/filme-listar/",
                    User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), null);

                return View(resultado.Resultado);
            }
            catch (Exception ex)
            {
                return Json(new JsonModel() { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ManterFilme(string cod)
        {
            try
            {
                if (string.IsNullOrEmpty(cod))
                {
                    Filme filme = new Filme();

                    return View(filme);
                }
                else
                {
                    ClientService client = new ClientService();

                    Filme resultado = await client.GetAsync<Filme>(_config["UrlApi"] + "/Filme/filme?IdFilme="
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
        public async Task<JsonResult> IncluirFilme(Filme filme)
        {
            try
            {
                try
                {
                    ClientService client = new ClientService();

                    if (filme.Arquivo != null)
                    {
                        Filme foto = SalvarImagem(filme.Arquivo);

                        filme.Imagem = foto.Imagem;
                        filme.Caminho = foto.Caminho;
                    }

                    filme.IdUsuario = User.Claims.Where(s => s.Type == "ID").Select(s => s.Value).First();
                    filme.Arquivo = null;

                    Notificacao resultado = await client.PostAsync<Filme>(_config["UrlApi"] + "/Filme/filme/",
                        User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), filme);

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
        public async Task<JsonResult> EditarFilme(Filme filme)
        {
            try
            {
                try
                {
                    ClientService client = new ClientService();

                    if (filme.Arquivo != null)
                    {
                        Filme foto = SalvarImagem(filme.Arquivo);

                        filme.Imagem = foto.Imagem.ToString();
                        filme.Caminho = foto.Caminho.ToString();
                    }

                    filme.IdUsuario = User.Claims.Where(s => s.Type == "ID").Select(s => s.Value).First();
                    filme.Arquivo = null;

                    Notificacao resultado = await client.PutAsync<Filme>(_config["UrlApi"] + "/Filme/filme/",
                    User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), filme);

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
        public async Task<IActionResult> ExcluirFilme(string cod)
        {
            try
            {
                ClientService client = new ClientService();

                Filme resultado = await client.GetAsync<Filme>(_config["UrlApi"] + "/Filme/filme?IdFilme="
                    , User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), cod);

                return View(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteFilme(string cod)
        {
            try
            {
                try
                {
                    ClientService client = new ClientService();

                    Notificacao resultado = await client.DeleteAsync<Notificacao>(_config["UrlApi"] + "/Filme/filme/?IdFilme="
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
        public async Task<IActionResult> GridFilme()
        {
            try
            {
                ClientService client = new ClientService();

                DadosFilme resultado = await client.GetAsync<DadosFilme>(_config["UrlApi"] + "/Filme/filme-listar/"
                    , User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), null);

                return PartialView("_GridFilme", resultado.Resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<JsonResult> CarregarComboboxFilme()
        {
            try
            {
                try
                {
                    ClientService client = new ClientService();

                    DadosFilme resultado = await client.GetAsync<DadosFilme>(_config["UrlApi"] + "/Filme/filme-listar/"
                        , User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), "");

                    if (resultado.Erro)
                    {
                        return Json(new JsonModel() { success = false, result = resultado.Resultado, message = resultado.Msg });
                    }

                    // return Json(new JsonModel() { success = true, result = resultado.Resultado.Select(s => new { s.IdFilme, s.Titulo }), message = resultado.Msg });
                    return Json(new { success = true, result = resultado.Resultado.Select(s => new { s.IdFilme, s.Titulo }) });
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

        public Filme SalvarImagem(IFormFile upload)
        {
            try
            {
                if (upload != null && upload.Length > 0)
                {
                    // Verifica a existencia do diretório
                    if (!Directory.Exists(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images"))))
                          Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images"));

                    // Nome da imagem que será salva no banco de dados 
                    //var nomeFoto = upload.FileName;
                    var nomeFoto = Convert.ToString(Guid.NewGuid() +"_"+ upload.FileName);

                    //Recuperando a configuração do arquivo appsettings de ontem será salvo o físico 
                    string configuracaoCaminho = _config.GetValue<string>("PathImages");

                    // Caminho do diretório 
                    var caminho = Path.Combine(configuracaoCaminho);
                    var caminhoCompleto = Path.Combine(caminho, nomeFoto);
            
                    using (Stream stream = new FileStream(caminhoCompleto, FileMode.Create))
                    {
                        upload.CopyToAsync(stream);
                    }

                    Filme filme = new Filme
                    {
                        Imagem = nomeFoto,
                        Caminho = caminho,
                    };

                    return filme;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}