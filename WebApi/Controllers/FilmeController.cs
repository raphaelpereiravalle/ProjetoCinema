using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoCinema.ApplicationService.Interface.Service;
using ProjetoCinema.Domain.Model;
using System;
using System.Threading.Tasks;

namespace ProjetoCinema.WebApi.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeAppService _filmeAppService;

        public FilmeController(IFilmeAppService filmeAppService)
        {
            _filmeAppService = filmeAppService;
        }

        [Route("filme")]
        [HttpPost]
        public async Task<Notificacao> IncluirFilme([FromBody] Filme filme)
        {
            if (ModelState.IsValid)
            {
                Notificacao notificacao = await _filmeAppService.IncluirFilme(filme);

                return notificacao;
            }
            return new Notificacao(true, "Envie informações corretas: ", null);
        }

        [Route("filme-listar")]
        [HttpGet]
        public async Task<DadosFilme> ListarFilme()
        {
            DadosFilme filme = await _filmeAppService.ListarFilme();
            return filme;
        }

        [Route("filme")]
        [HttpGet]
        public async Task<Filme> BuscarFilme(string idFilme)
        {
            try
            {
                return await _filmeAppService.BuscarFilme(idFilme);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [Route("filme")]
        [HttpPut]
        public async Task<Notificacao> EditarFilme([FromBody] Filme filme)
        {
            if (ModelState.IsValid)
            {
                Notificacao notificacao = await _filmeAppService.EditarFilme(filme);
                return notificacao;
            }
            return new Notificacao(true, "Envie as informações corretas", null);
        }

        [Route("filme")]
        [HttpDelete]
        public async Task<Notificacao> DeleteFilme(string idFilme)
        {
            if (!string.IsNullOrEmpty(idFilme))
            {
                Notificacao notificacao = await _filmeAppService.ExcluirFilme(idFilme);
                return notificacao;
            }
            return new Notificacao(true, "Envie informações corretas", null);
        }

        [Route("contador")]
        [HttpGet]
        public async Task<int> ContadorFilme()
        {
            return await _filmeAppService.ContadorFilme();
        }
    }
}
