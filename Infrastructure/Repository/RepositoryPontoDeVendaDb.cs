using Domain.Interfaces;
using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryPontoDeVendaDb : Repository<PontoDeVenda>, IRepositoryPontoDeVenda
    {

        public RepositoryPontoDeVendaDb(CookieDbContext context) : base(context)
        {

        }

        public CookieDbContext CookieDbContext
        {
            get { return Context as CookieDbContext; }
        }
    }
}
