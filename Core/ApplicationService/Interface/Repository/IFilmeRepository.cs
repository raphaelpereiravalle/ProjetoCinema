using ProjetoCinema.Domain.Model;
using System.Threading.Tasks;

namespace ProjetoCinema.ApplicationService.Interface.Repository
{
    public interface IFilmeRepository
    {
        Task<Notificacao> IncluirFilme(Filme filme);
        Task<DadosFilme> ListarFilme();
        Task<Filme> BuscarFilme(string idFilme);
        Task<Notificacao> EditarFilme(Filme filme);
        Task<Notificacao> ExcluirFilme(string idFilme);
        Task<int> ContadorFilme();
    }
}
