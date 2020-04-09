using CarlosTest.Controllers;
using CarlosTest.Services;
using DataDB.Data;
using DataDB.Repositories;
using DataDB.Repository;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace CarlosTest
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            // e.g. container.RegisterType<ITestService, TestService>();
            //Repos
            container.RegisterType<IFeedRepository, FeedRepository>();
            container.RegisterType<IUserRepository, UserRepository>();

            //Services
            container.RegisterType<IFeedService, FeedService>();
            container.RegisterType<IUserService, UserService>();
            ///config.DependencyResolver = new UnityResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        
}
    }
}