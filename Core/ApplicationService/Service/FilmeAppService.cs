using ProjetoCinema.ApplicationService.Interface.Repository;
using ProjetoCinema.ApplicationService.Interface.Service;
using ProjetoCinema.Domain.Model;
using System.Threading.Tasks;

namespace ProjetoCinema.ApplicationService.Service
{
    public class FilmeAppService : IFilmeAppService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeAppService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public Task<Notificacao> IncluirFilme(Filme filme)
        {
            return _filmeRepository.IncluirFilme(filme);
        }

        public Task<DadosFilme> ListarFilme()
        {
            return _filmeRepository.ListarFilme();
        }

        public Task<Filme> BuscarFilme(string idFilme) 
        
        {
            return _filmeRepository.BuscarFilme(idFilme);
        }

        public Task<Notificacao> EditarFilme(Filme filme)
        {
            return _filmeRepository.EditarFilme(filme);
        }

        public Task<Notificacao> ExcluirFilme(string idFilme)
        {
            return _filmeRepository.ExcluirFilme(idFilme);
        }

        public Task<int> ContadorFilme()
        {
            return _filmeRepository.ContadorFilme();
        }
    }
}
