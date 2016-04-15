using Domain.Interfaces;
using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public static class ServiceValidation
    {

        public static bool Exists(this Produto produto, IRepositoryProduto produtos)
        {
            if (produtos.ObterPorId(produto.Id) != null)
                return true;
            return false;
        }

        public static bool Exists(this PontoDeVenda pontoDeVenda, IRepositoryPontoDeVenda pontosDeVenda)
        {
            if (pontosDeVenda.ObterPorId(pontoDeVenda.Id) != null)
                return true;
            return false;
        }

        public static bool Exists(this Lote lote, IRepositoryPontoDeVenda lotes)
        {
            if (lotes.ObterPorId(lote.Id) != null)
                return true;
            return false;
        }

        public static bool Exists(this Pedido pedido, IRepositoryPedido pedidos)
        {
            if (pedidos.ObterPorId(pedido.Id) != null)
                return true;
            return false;
        }

        
    }
}
