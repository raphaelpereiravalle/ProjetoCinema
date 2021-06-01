using ProjetoCinema.Domain.Model;
using System.Threading.Tasks;

namespace ProjetoCinema.ApplicationService.Interface.Repository
{
    public interface IFilmeRepository
    {
        Task<Notificacao> IncluirFilme(Filme filme);
        Task<DadosFilme> ListarFilme();
        Task<Filme> BuscarFilme(string idFilme);
        Task<Notificacao> BuscarFilmePorTitulo(string filme);
        Task<Notificacao> BuscarFilmeSessaoId(string idFilme);
        Task<Notificacao> EditarFilme(Filme filme);
        Task<Notificacao> ExcluirFilme(string idFilme);
        void ExcluirImagem(string caminho, string arquivo);
        Task<int> ContadorFilme();
        Task<Filme> BuscarImagemCaminho(string idFilme);
    }
}
