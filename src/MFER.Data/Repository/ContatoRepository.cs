using MFER.Business.Interfaces;
using MFER.Business.Models;
using MFER.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MFER.Data.Repository;

public class ContatoRepository(MferDbContext _mferDbContext, DbSet<Contato> _entitySet) : Repository<Contato>(_mferDbContext, _entitySet), IContatoRepository
{
    public async Task<int> ObterTotalDeContatos()
    {
        return await _mferDbContext.Contatos.CountAsync();
    }
}