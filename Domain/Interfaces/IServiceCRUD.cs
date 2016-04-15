using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IServiceCRUD<T> where T : class
    {
        void Cadastrar(T entity);
        IEnumerable<T> Buscar();
        IEnumerable<T> Buscar(Func<T, bool> predicate);
        void Atualizar(T entity);
        void Excluir(T entity);
        void Excluir(int Id);
    }
}
