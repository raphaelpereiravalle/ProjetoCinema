using ProjetoCinema.Domain.Model;
using System.Threading.Tasks;

namespace ProjetoCinema.ApplicationService.Interface.Repository
{
    public interface ISessaoRepository
    {
        Task<Notificacao> IncluirSessao(Sessao sessao);
        Task<DadosSessao> ListarSessao();
        Task<Sessao> BuscarSessao(string idSessao);
        Task<Notificacao> VerificarExisteSalaSessao(string idSala, string horaInicioSessao);
        Task<Notificacao> EditarSessao(Sessao sessao);
        Task<Notificacao> ExcluirSessao(string idSessao);
        string CalculadoHoraFinal(string idFilme, string horarioInicio);
        Task<double> MediaValorIngresso();
        int CalcularPrazoParaExcluirSessao(string idSessao);
    }
}
