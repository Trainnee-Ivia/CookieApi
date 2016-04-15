using Domain.Interfaces;
using Domain.Objetos;
using Domain.Services;
using Infrastructure;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //CookieDbContext context = new CookieDbContext();
            //IUnitOfWork uow = new UnitOfWorkDb(context);

            var produto = new Produto(1, "m", 15, 1.30m);
            
        }
    }
}
