using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoCinema.ApplicationService.Interface.Service;
using ProjetoCinema.Domain.Model;
using System.Threading.Tasks;

namespace ProjetoCinema.WebApi.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ISalaAppService _SalaAppService;

        public SalaController(ISalaAppService SalaAppService)
        {
            _SalaAppService = SalaAppService;
        }

        [Route("listar-sala")]
        [HttpGet]
        public async Task<DadosSala> ListarSala()
        {
            return await _SalaAppService.ListarSala();
        }
    }
}
