using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using AbstractShopBusinessLogic.BusinessLogics;
using AbstractShopContracts.BusinessLogicsContracts;
using AbstractShopContracts.StoragesContacts;
using AbstractShopListImplement.Implements;

namespace AbstractShopView
{
    static class Program
    {
        private static IUnityContainer container = null;
        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = BuildUnityContainer();
                }
                return container;
            }
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IComponentStorage,
            ComponentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, IOrderStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductStorage, ProductStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IComponentLogic, ComponentLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, IOrderLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductLogic, IProductLogic>(new
            HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
