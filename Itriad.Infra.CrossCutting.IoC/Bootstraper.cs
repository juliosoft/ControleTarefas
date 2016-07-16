using CommonServiceLocator.SimpleInjectorAdapter;
using Itriad.Domain.Interfaces.Repositories;
using Itriad.Infra.Data.Context;
using Itriad.Infra.Data.Repositories;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itriad.Infra.CrossCutting.IoC
{
    /// <summary>
    /// Install-package SimpleInjector
    /// Install-package CommonServiceLocator -Version 1.3.0
    /// Install-package CommonServiceLocator.SimpleInjectorAdapter
    /// Classe para configuração de injeção de dependencia
    /// </summary>
    public class Bootstraper
    {
        /// <summary>
        /// Registra a injeção de dependencia
        /// </summary>
        /// <param name="container"></param>
        public static void RegisterServices(Container container)
        {
            try
            {
                container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

                container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);
                container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
                //container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);

                //container.Register(typeof(IServiceBaseDomain<>), typeof(ServiceBaseDomain<>), Lifestyle.Scoped);
                //container.Register<IClienteServiceDomain, ClienteServiceDomain>(Lifestyle.Scoped);
                //container.Register<IProdutoServiceDomain, ProdutoServiceDomain>(Lifestyle.Scoped);

                //container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>), Lifestyle.Scoped);
                //container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
                //container.Register<IProdutoAppService, ProdutoAppService>(Lifestyle.Scoped);

                // Security
                //container.RegisterPerWebRequest<ApplicationDbContext>();
                //container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
                //container.RegisterPerWebRequest<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>());
                //container.RegisterPerWebRequest<ApplicationRoleManager>();
                //container.RegisterPerWebRequest<ApplicationUserManager>();
                //container.RegisterPerWebRequest<ApplicationSignInManager>();
                //container.RegisterPerWebRequest<IUsuarioRepository, UsuarioRepository>();
                //

                ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
            }
            catch (System.Exception e)
            {

                throw;
            }

        }
    }
}
