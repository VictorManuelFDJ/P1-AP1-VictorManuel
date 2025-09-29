using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using P1_AP1_VictorManuel.Dal;
using P1_AP1_VictorManuel.Models;

namespace P1_AP1_VictorManuel.Services;

public class RegistroServices(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<List<EntradaHuacales>> Listar(Expression<Func<EntradaHuacales, bool>> criterio) 
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Registros
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

}
