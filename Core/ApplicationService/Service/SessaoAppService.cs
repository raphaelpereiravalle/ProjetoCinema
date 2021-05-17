using ProjetoCinema.ApplicationService.Interface.Repository;
using ProjetoCinema.ApplicationService.Interface.Service;
using ProjetoCinema.Domain.Model;
using System.Threading.Tasks;

namespace ProjetoCinema.ApplicationService.Service
{
    public class SessaoAppService : ISessaoAppService
    {
        private readonly ISessaoRepository _sessaoRepository;

        public SessaoAppService(ISessaoRepository sessaoRepository)
        {
            _sessaoRepository = sessaoRepository;
        }

        public Task<Notificacao> IncluirSessao(Sessao Sessao)
        {
            return _sessaoRepository.IncluirSessao(Sessao);
        }

        public Task<DadosSessao> ListarSessao()
        {
            return _sessaoRepository.ListarSessao();
        }

        public Task<Sessao> BuscarSessao(string idSessao) 
        {
            return _sessaoRepository.BuscarSessao(idSessao);
        }

        public Task<Notificacao> EditarSessao(Sessao Sessao)
        {
            return _sessaoRepository.EditarSessao(Sessao);
        }

        public Task<Notificacao> ExcluirSessao(string idSessao)
        {
            return _sessaoRepository.ExcluirSessao(idSessao);
        }

        public Task<double> MediaValorIngresso()
        {
            return _sessaoRepository.MediaValorIngresso();
        }
    }
}
