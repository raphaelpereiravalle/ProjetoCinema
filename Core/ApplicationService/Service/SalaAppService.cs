using ProjetoCinema.ApplicationService.Interface.Repository;
using ProjetoCinema.ApplicationService.Interface.Service;
using ProjetoCinema.Domain.Model;
using System.Threading.Tasks;

namespace ProjetoCinema.ApplicationService.Service
{
    public class SalaAppService : ISalaAppService
    {
        private readonly ISalaRepository _salaRepository;

        public SalaAppService(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public Task<DadosSala> ListarSala()
        {
            return _salaRepository.ListarSala();
        }
    }
}
