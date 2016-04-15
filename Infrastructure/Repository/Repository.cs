using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Excluir(int id)
        {
            var entity = this.ObterPorId(id);
            Context.Set<T>().Remove(entity);
        }

        public void Excluir(T Entity)
        {
            Context.Set<T>().Remove(Entity);
        }

        public void Inserir(T Entity)
        {
            Context.Set<T>().Add(Entity);
        }

        public T ObterPorId(int? id)
        {
            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return Context.Set<T>().ToList();
        }

        public IEnumerable<T> ObterTodos(Func<T, bool> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }
    }
}
