using Domain.Interfaces;
using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServicePedido
    {
        private IUnitOfWork _uow;

        public ServicePedido(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public void CompletarPedido(Pedido pedido)
        {
            if (pedido.ItensDoPedido.Count == 0)
                throw new InvalidOperationException("Por favor adicione no minimo um Item ao pedido.");

            foreach(var item in pedido.ItensDoPedido)
            {
                RetirarItemDoEstoque(item);
            }

            _uow.PedidoRepository.Inserir(pedido);

            _uow.SalvarAlteracoes();
        }

        private void RetirarItemDoEstoque(ItemDoPedido itemDoPedido)
        {
            var lotes = _uow.LoteRepository.ObterLotesDisponiveisParaRetirada(5, itemDoPedido.Produto);
            if (!VerificarQuantidadeDosLotes(ref lotes, itemDoPedido.Quantidade))
                throw new InvalidOperationException("Quantidade em estoque inferior a quantidade do item pedido.");

            var quantidadeTemp = itemDoPedido.Quantidade;
            var valorAux = 0;
            var quantidadeRetirada = 0;
            foreach(var lote in lotes)
            {
                if (quantidadeTemp == 0)
                    break;

                valorAux = lote.QuantidadeEmEstoque - quantidadeTemp;

                if(valorAux >= 0)
                {
                    quantidadeRetirada = quantidadeTemp;
                    lote.QuantidadeEmEstoque = valorAux;
                    quantidadeTemp = 0;
                }
                else
                {
                    quantidadeRetirada = lote.QuantidadeEmEstoque;
                    lote.QuantidadeEmEstoque = 0;
                    quantidadeTemp = Math.Abs(valorAux);
                }

                var historicoDeRetiradaDoLote = new HistoricoDeRetiradaDoLote(lote, itemDoPedido, quantidadeRetirada);

                itemDoPedido.HistoricoDeRetiradaDosLotes.Add(historicoDeRetiradaDoLote);
            }
        }

        //private void AdicionarNoHistoricoDeLote(ref ItemDoPedido itemDoPedido, Lote lote, int quantidadeRetirada)
        //{
        //    var historicoDeRetiradaDoLote = new HistoricoDeRetiradaDoLote(lote, itemDoPedido, quantidadeRetirada);
        //    itemDoPedido.HistoricoDeRetiradaDosLotes.Add(historicoDeRetiradaDoLote);
        //}

        private bool VerificarQuantidadeDosLotes(ref IEnumerable<Lote> lotes, int quantidade)
        {
            var quantidadeTotal = lotes.Sum(l => l.QuantidadeEmEstoque);
            if (quantidadeTotal >= quantidade)
            {
                return true;
            }
            return false;
        }
    }
}
