using Autofac;
using Caliburn.Micro;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TodoApp.MVVM;
using TodoApp.MVVM.IViewModels;
using TodoApp.MVVM.Services;
using TodoAppMVVM.Services;
using TodoAppMVVM.SQLite;
using TodoAppMVVM.ViewModels;
using TodoAppMVVM.Views;

namespace TodoAppMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NinjectConfiguration DI;
        public App()
        {
            DI = new NinjectConfiguration();
        }
        private void App_Startup(object sender, StartupEventArgs e)
        {

            var kernel = DI.Configure();
            var appVM = kernel.Get<MainViewModel>();

            MainWindow = new MainView();
            MainWindow.DataContext = appVM;
            MainWindow.Show();

            /*--------------------------------------OPTION 1--------------------------------------
            var dialogService = new DialogService();
            var dataService = new DataService(dialogService);
            var dataVM = new DataViewModel(dataService);
            var appVM = new AppViewModel(dataVM);

            MainWindow = new MainWindow();
            MainWindow.DataContext = appVM;
            MainWindow.Show();
            ------------------------------------------------------------------------------------

            --------------------------------------OPTION 2--------------------------------------
            MainWindow = new MainWindow();
            MainWindow.DataContext = new AppViewModel(new DataViewModel(new DataService(new DialogService())));
            MainWindow.Show();
            ------------------------------------------------------------------------------------ */
        }
       
    }
}
