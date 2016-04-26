
namespace ApiRest.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Domain.Interfaces;
    using Infrastructure.Repository;
    using System.Reflection;
    public static class NinjectWebCommon 
    {
        public static Lazy<IKernel> CreateKernel = new Lazy<IKernel>(() =>
        {
            StandardKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            RegisterServices(kernel);

            return kernel;
        });
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            
           
            kernel.Bind<IUnitOfWork>().To<UnitOfWorkDb>();
            kernel.Bind<IRepositoryLote>().To<RepositoryLoteDb>();
            kernel.Bind<IRepositoryProduto>().To<RepositoryProdutoDb>();
            kernel.Bind<IRepositoryPedido>().To<RepositoryPedidoDb>();
            kernel.Bind<IRepositoryPontoDeVenda>().To<RepositoryPontoDeVendaDb>();
            kernel.Bind<RepositoryAuthDb>().ToSelf();

            
        }        
    }
}
