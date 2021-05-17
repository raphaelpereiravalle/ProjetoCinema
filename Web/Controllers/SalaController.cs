﻿using Microsoft.AspNetCore.Authorization;
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
    public class SalaController : Controller
    {
        private readonly IConfiguration _config;

        public SalaController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                ClientService client = new ClientService();

                DadosSala resultado = await client.GetAsync<DadosSala>(_config["UrlApi"] + "/Sala/listar-sala/", 
                    User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), null);

                return View(resultado.Resultado);
            }
            catch (Exception ex)
            {
                return Json(new JsonModel() { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<JsonResult> ListarSala()
        {
            try
            {
                try
                {
                    ClientService client = new ClientService();

                    DadosSala resultado = await client.GetAsync<DadosSala>(_config["UrlApi"] + "/Sala/listar-sala/"
                        , User.Claims.Where(s => s.Type == "AccessToken").Select(s => s.Value).First(), "");

                    if (resultado.Erro)
                    {
                        return Json(new JsonModel() { success = false, result = resultado.Resultado, message = resultado.Msg });
                    }
                    return Json(new { success = true, result = resultado.Resultado.Select(s => new { s.IdSala, s.Nome }) });
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
    }
}
