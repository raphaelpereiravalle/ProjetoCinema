using ProjetoCinema.Domain.Model;
using System.Threading.Tasks;

namespace ProjetoCinema.ApplicationService.Interface.Repository
{
    public interface ISalaRepository
    {
        Task<DadosSala> ListarSala();
    }
}
