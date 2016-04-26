using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Infrastructure.Repository
{
    public class RepositoryUsuarioDb
    {
        public CookieDbContext CookieDbContext { get; set; }
        public RepositoryUsuarioDb(CookieDbContext context)
        {
            CookieDbContext = context;
        }

        public Usuario ObterPorId(string id)
        {
            return CookieDbContext.Usuarios.Find(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return CookieDbContext.Usuarios.ToList();
        }

        public IEnumerable<Usuario> ObterTodos(Func<Usuario, bool> predicate)
        {
            return CookieDbContext.Usuarios.Where(predicate).ToList();
        }

        public Usuario ObterPorEmail(string email)
        {
            return CookieDbContext.Usuarios.Where(u => u.Email == email).FirstOrDefault();
        }
    }
}
