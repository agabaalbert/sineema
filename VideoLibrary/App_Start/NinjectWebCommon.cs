using VideoLibrary.BusinessLogic.Repositories.ActorRepository;
using VideoLibrary.BusinessLogic.Repositories.ClientRepository;
using VideoLibrary.BusinessLogic.Repositories.MovieActorRepository;
using VideoLibrary.BusinessLogic.Repositories.MovieRepository;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;
using VideoLibrary.BusinessLogic.Services.ClientCrudService;
using VideoLibrary.BusinessLogic.Services.MovieCrudService;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(VideoLibrary.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(VideoLibrary.App_Start.NinjectWebCommon), "Stop")]

namespace VideoLibrary.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

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
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IActorRepository>().To<ActorRepository>();
            kernel.Bind<IMovieRepository>().To<MovieRepository>();
            kernel.Bind<IActorService>().To<ActorService>();
            kernel.Bind<IMovieService>().To<MovieService>();
            kernel.Bind<IClientRepository>().To<ClientRepository>();
            kernel.Bind<IClientCrudService>().To<ClientCrudService>();
            kernel.Bind<IMovieActorRepository>().To<MovieActorRepository>();
        }        
    }
}
