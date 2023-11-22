using limaApi.Contexts;
using limaApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace limaApi.Repositories
{
    public class RankingRepository
    {
        LimaContext ctx = new LimaContext();

        public List<PersonModel> CalculateRanking()
        {
            var lista = ctx.Participantes
               .Include(x => x.Venda)
               .ThenInclude(x => x.Produto)
               .Include(x => x.Cidade)
               .ThenInclude(x => x.Estado)
               .Where(x => x.Venda.Count() > 0).ToList()
               .Select(x => new PersonModel
               {
                   Nome = x.Nome,
                   Idade = x.Idade,
                   CidadeNome = x.Cidade.Cidade1,
                   EstadoNome = x.Cidade.Estado.Sigla,
                   Genero = x.Genero,
                   Pontos = x.Venda.Count() * 12 + x.Venda.Sum(r => r.Produto.Valor) * 24
               }).OrderByDescending(x => x.Pontos).ToList();

            return lista;
        }
    }
}
