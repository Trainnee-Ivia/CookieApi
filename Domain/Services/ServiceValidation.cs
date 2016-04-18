using Domain.Interfaces;
using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceValidation
    {

        public static bool Exists(int produtoId, IRepositoryProduto produtos)
        {
            if (produtos.ObterPorId(produtoId) != null)
                return true;
            return false;
        }

        public static bool Exists(int pontoDeVendaId, IRepositoryPontoDeVenda pontosDeVenda)
        {
            if (pontosDeVenda.ObterPorId(pontoDeVendaId) != null)
                return true;
            return false;
        }

        public static bool Exists(int loteId, IRepositoryLote lotes)
        {
            if (lotes.ObterPorId(loteId) != null)
                return true;
            return false;
        }

        public static bool Exists(int pedidoId, IRepositoryPedido pedidos)
        {
            if (pedidos.ObterPorId(pedidoId) != null)
                return true;
            return false;
        }

        
    }
}
