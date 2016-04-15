using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Interfaces;
using Domain.Objetos;
using Domain.Services;
using System.Linq;
using Domain.Tests.Fakes;

namespace Domain.Tests
{
    [TestClass]
    public class ServiceProdutoTest
    {
        private Mock<IUnitOfWork> _unitOfWorkMoq;

        [TestInitialize]
        public void Initicializador()
        {
            _unitOfWorkMoq = new Mock<IUnitOfWork>();
            
            _unitOfWorkMoq.Setup(u => u.ProdutoRepository).Returns(new RepositoryProdutoFake());
        }

        [TestMethod]
        public void Cadastrar_Um_Produto_Eh_Deve_Constar_No_Repositorio()
        {
            
            var produtoService = new ServiceProduto(_unitOfWorkMoq.Object);

            var produto = new Produto(1, "Tradicional", 15, 2.30m);

            produtoService.Cadastrar(produto);

            var produtoResult = produtoService.Buscar().FirstOrDefault();
            Assert.IsTrue(produto.Id == produtoResult.Id);
        }
    }
}
