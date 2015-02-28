using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using negocio.Dominio;
using negocio.Intermediario;
using negocio.Intermediario.Carro;
using negocio.Intermediario.Cliente;
using negocio.Intermediario.Fornecedor;
using negocio.Intermediario.Produto;
using negocio.UI.Web.App_Start;
using Ninject;
using Ninject.Web.Common;
using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof (NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof (NinjectWebCommon), "Stop")]

namespace negocio.UI.Web.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        ///     Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof (OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof (NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        ///     Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        ///     Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                kernel.Bind<ICrud<CarroDTO>>().To<CarroIntermediario>();
                kernel.Bind<ICrud<ClienteDTO>>().To<ClienteIntermediario>();
                kernel.Bind<ICrud<FornecedorDTO>>().To<FornecedorIntermediario>();
                kernel.Bind<ICrud<ProdutoDTO>>().To<ProdutoIntermediario>();
                kernel.Bind<ICrud<ProdutoCategoriaDTO>>().To<ProdutoCategoriaIntermediario>();


                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        ///     Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }
    }
}