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
    public class SessaoController : ControllerBase
    {
        private readonly ISessaoAppService _SessaoAppService;

        public SessaoController(ISessaoAppService SessaoAppService)
        {
            _SessaoAppService = SessaoAppService;
        }

        [Route("sessao")]
        [HttpPost]
        public async Task<Notificacao> IncluirSessao([FromBody] Sessao sessao)
        {
            if (ModelState.IsValid)
            {
                Notificacao notificacao = await _SessaoAppService.IncluirSessao(sessao);
                return notificacao;
            }
            return new Notificacao(true, "Envie informações corretas: ", null);
        }

        [Route("listar-sessao")]
        [HttpGet]
        public async Task<DadosSessao> ListarSessao()
        {
            DadosSessao sessao = await _SessaoAppService.ListarSessao();
            return sessao;
        }

        [Route("sessao")]
        [HttpGet]
        public async Task<Sessao> BuscarSessao(string idSessao)
        {
            try
            {
                return await _SessaoAppService.BuscarSessao(idSessao);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [Route("sessao")]
        [HttpPut]
        public async Task<Notificacao> Editar([FromBody] Sessao sessao)
        {
            if (ModelState.IsValid)
            {
                Notificacao notificacao = await _SessaoAppService.EditarSessao(sessao);
                return notificacao;
            }
            return new Notificacao(true, "Envie as informações corretas", null);
        }

        [Route("sessao")]
        [HttpDelete]
        public async Task<Notificacao> DeleteSessao(string idSessao)
        {
            if (!string.IsNullOrEmpty(idSessao))
            {
                Notificacao notificacao = await _SessaoAppService.ExcluirSessao(idSessao);
                return notificacao;
            }
            return new Notificacao(true, "Envie informações corretas", null);
        }

        [Route("media")]
        [HttpGet]
        public async Task<double> MediaValorIngresso()
        {
            return await _SessaoAppService.MediaValorIngresso();
        } 
    }
}
