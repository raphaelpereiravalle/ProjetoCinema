using ProjetoCinema.Domain.Model;
using System.Threading.Tasks;

namespace ProjetoCinema.ApplicationService.Interface.Service
{
    public interface IFilmeAppService
    {
        Task<Notificacao> IncluirFilme(Filme filme);
        Task<DadosFilme> ListarFilme();
        Task<Filme> BuscarFilme(string idFilme);
        Task<Notificacao> EditarFilme(Filme filme);
        Task<Notificacao> ExcluirFilme(string idFilme);
        Task<int> ContadorFilme();
    }
}
