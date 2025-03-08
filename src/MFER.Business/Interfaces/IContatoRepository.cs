using MFER.Business.Models;

namespace MFER.Business.Interfaces;

public interface IContatoRepository : IRepository<Contato>
{
    Task<int> ObterTotalDeContatos();
}