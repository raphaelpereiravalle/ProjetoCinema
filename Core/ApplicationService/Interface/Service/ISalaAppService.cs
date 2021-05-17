using ProjetoCinema.Domain.Model;
using System.Threading.Tasks;

namespace ProjetoCinema.ApplicationService.Interface.Service
{
    public interface ISalaAppService
    {
        Task<DadosSala> ListarSala();
    }
}
