using Autofac;
using OrderManagement.Data.Interface.Service;
using OrderManagement.Data.Service;
using OrderManagement.Interface;
using OrderManagement.Service;
using OrderManagement.View;
using OrderManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    internal class BootStrapper
    {
        public object Run(string[] args)
        {
            try
            {
                var container = BuildContainer();

                var mainWindow = container.Resolve<MainWindow>();

                mainWindow.Show();

                return mainWindow;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>();
            builder.RegisterType<MarketSummaryView>().As<IMarketSummaryView>();

            builder.RegisterType<PlaceOrderWindow>();
            builder.RegisterType<PlaceOrderView>().As<IPlaceOrderView>();
 
            builder.RegisterType<MainWindowViewModel>();
            builder.RegisterType<MarketSummaryViewModel>();
            builder.RegisterType<PlaceOrderWindowViewModel>();
            builder.RegisterType<PlaceOrderViewModel>();

            builder.RegisterType<ProductDataService>().As<IProductDataService>();
            builder.RegisterType<ProductMarketDataService>().As<IProductMarketDataService>();
            builder.RegisterType<DemoPriceService>().As<IPriceService>();
            builder.RegisterType<DefaultMessageService>().As<IMessageService>();
            builder.RegisterType<Log>().As<ILog>();
            


            return builder.Build();
        }
    }
}
