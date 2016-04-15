using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Interfaces;
using Domain.Tests.Fakes;
using Domain.Objetos;
using Domain.Services;

namespace Domain.Tests
{
    [TestClass]
    public class ServicePedidoTest
    {
        private Mock<IUnitOfWork> _uow;

        [TestInitialize]
        public void Iniciar()
        {
            _uow = new Mock<IUnitOfWork>();

            _uow.Setup(u => u.ProdutoRepository).Returns(new RepositoryProdutoFake());
            _uow.Setup(u => u.LoteRepository).Returns(new RepositoryLoteFake());
            _uow.Setup(u => u.PontoDeVendaRepository).Returns(new RepositoryPontoDeVendaFake());
            _uow.Setup(u => u.PedidoRepository).Returns(new RepositoryPedidoFake());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Fazer_Um_Pedido_Com_PontoDeVenda_Que_Nao_Exite_Retorna_Error()
        {
            var enderecoPonto = new Endereco("Rua Beija Flor", 101, "A", "04953656377");
            var pontoDeVenda = new PontoDeVenda(2, "85999999999", "Ponto1", "Michel", enderecoPonto);

            var produto = new Produto(1, "Tradicional", 15, 3.20m);
            var itemDoPedido = new ItemDoPedido(produto, 20);

            var pedido = new Pedido(DateTime.Now, pontoDeVenda);
            pedido.AdiconarItemAoPedido(itemDoPedido);

            var pedidoService = new ServicePedido(_uow.Object);

            pedidoService.CompletarPedido(pedido);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Fazer_Um_Pedido_Sem_Item_Retorna_Error()
        {
            var pontoDeVenda = _uow.Object.PontoDeVendaRepository.ObterPorId(1);

            var pedido = new Pedido(DateTime.Now, pontoDeVenda);

            var pedidoService = new ServicePedido(_uow.Object);

            pedidoService.CompletarPedido(pedido);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Fazer_Um_Pedido_Com_Produto_Que_Nao_Exite_Retorna_Error()
        {
            var pontoDeVenda = _uow.Object.PontoDeVendaRepository.ObterPorId(1);

            var produto = new Produto(1, "Tradicional", 15, 3.20m);
            var itemDoPedido = new ItemDoPedido(produto, 20);

            var pedido = new Pedido(DateTime.Now, pontoDeVenda);
            pedido.AdiconarItemAoPedido(itemDoPedido);

            var pedidoService = new ServicePedido(_uow.Object);

            pedidoService.CompletarPedido(pedido);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Fazer_Um_Pedido_Com_QuantidadeDoPedido_Maior_Que_Ah_QuandadeEmEstoque_Retorna_Error()
        {
            var pontoDeVenda = _uow.Object.PontoDeVendaRepository.ObterPorId(1);

            var produto = _uow.Object.ProdutoRepository.ObterPorId(1);
            var itemDoPedido = new ItemDoPedido(produto, 20);

            var pedido = new Pedido(DateTime.Now, pontoDeVenda);
            pedido.AdiconarItemAoPedido(itemDoPedido);

            var pedidoService = new ServicePedido(_uow.Object);

            pedidoService.CompletarPedido(pedido);
        }

        [TestMethod]
        
        public void Fazer_Um_Pedido_Com_Dados_Validos_Eh_Deve_Esta_Cadastrado()
        {
            var pontoDeVenda = _uow.Object.PontoDeVendaRepository.ObterPorId(1);

            var produto = _uow.Object.ProdutoRepository.ObterPorId(1);
            var itemDoPedido = new ItemDoPedido(produto, 10);

            var pedido = new Pedido(1, DateTime.Now, pontoDeVenda);
            pedido.AdiconarItemAoPedido(itemDoPedido);

            var pedidoService = new ServicePedido(_uow.Object);

            pedidoService.CompletarPedido(pedido);

            var pedidoResult = _uow.Object.PedidoRepository.ObterPorId(pedido.Id);

            Assert.IsTrue(pedido.Id == pedidoResult.Id);
        }
    }
}
