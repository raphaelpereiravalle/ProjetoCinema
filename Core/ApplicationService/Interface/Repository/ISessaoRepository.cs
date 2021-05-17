using ProjetoCinema.Domain.Model;
using System.Threading.Tasks;

namespace ProjetoCinema.ApplicationService.Interface.Repository
{
    public interface ISessaoRepository
    {
        Task<Notificacao> IncluirSessao(Sessao sessao);
        Task<DadosSessao> ListarSessao();
        Task<Sessao> BuscarSessao(string idSessao);
        Task<Notificacao> EditarSessao(Sessao sessao);
        Task<Notificacao> ExcluirSessao(string idSessao);
        Task<double> MediaValorIngresso();
    }
}
