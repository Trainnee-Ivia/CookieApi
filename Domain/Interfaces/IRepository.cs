using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> ObterTodos();
        IEnumerable<T> ObterTodos(Func<T, bool> predicate);
        T ObterPorId(int? id);
        void Inserir(T Entity);
        void Excluir(T Entity);
        void Excluir(int id);
    }
}
