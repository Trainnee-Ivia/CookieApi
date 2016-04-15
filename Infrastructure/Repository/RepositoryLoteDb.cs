using Domain.Interfaces;
using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryLoteDb : Repository<Lote>, IRepositoryLote
    {
        public RepositoryLoteDb(CookieDbContext context) : base(context)
        {

        }
        public IEnumerable<Lote> ObterLotesDisponiveisParaRetirada(int diasValidos, Produto produto)
        {
            return ObterTodos(l =>
                                (l.DataDeValidade.Ticks >= DateTime.Now.AddDays(diasValidos).Ticks) &&
                                (l.QuantidadeEmEstoque > 0))
                                .OrderBy(l => l.DataDeValidade);
        }

        public CookieDbContext CookieDbContext
        {
            get { return Context as CookieDbContext; }
        }
    }
}
