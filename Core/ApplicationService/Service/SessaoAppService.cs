using ProjetoCinema.ApplicationService.Interface.Repository;
using ProjetoCinema.ApplicationService.Interface.Service;
using ProjetoCinema.Domain.Model;
using System.Threading.Tasks;

namespace ProjetoCinema.ApplicationService.Service
{
    public class SessaoAppService : ISessaoAppService
    {
        private const int PRAZO_EXCLLUSAO_FILME = 10;
        private readonly ISessaoRepository _sessaoRepository;

        public SessaoAppService(ISessaoRepository sessaoRepository)
        {
            _sessaoRepository = sessaoRepository;
        }

        public Task<Notificacao> IncluirSessao(Sessao sessao)
        {
            var verificar = _sessaoRepository.VerificarExisteSalaSessao(sessao.IdSala, sessao.HoraInicioSessao);

            if (verificar.Result.Erro)
            {
                return verificar;
            }
            // Calcular horario final do filme
            sessao.HoraFimSessao = _sessaoRepository.CalculadoHoraFinal(sessao.IdFilme, sessao.HoraInicioSessao);

            return _sessaoRepository.IncluirSessao(sessao);
        }

        public Task<DadosSessao> ListarSessao()
        {
            return _sessaoRepository.ListarSessao();
        }

        public Task<Sessao> BuscarSessao(string idSessao)
        {
            return _sessaoRepository.BuscarSessao(idSessao);
        }

        public Task<Notificacao> EditarSessao(Sessao sessao)
        {
            // Calcular horario final do filme
            sessao.HoraFimSessao = _sessaoRepository.CalculadoHoraFinal(sessao.IdFilme, sessao.HoraInicioSessao);

            return _sessaoRepository.EditarSessao(sessao);
        }

        public async Task<Notificacao> ExcluirSessao(string idSessao)
        {
            // Retorno o calculo com o prazo para permitir a exclusão.
            // Uma sessão só pode ser removida se faltar 10 dias ou mais para que ela ocorra.
            int verificarSessao = _sessaoRepository.CalcularPrazoParaExcluirSessao(idSessao);

            if (verificarSessao >= PRAZO_EXCLLUSAO_FILME)
            {
                return await _sessaoRepository.ExcluirSessao(idSessao);
            }
            else
            {
                return new Notificacao(true, "A sessão não pode ser excluir poís faltam 10 dias ou mais para que ela ocorra...", null);
            }
        }

        public Task<double> MediaValorIngresso()
        {
            return _sessaoRepository.MediaValorIngresso();
        }
    }
}