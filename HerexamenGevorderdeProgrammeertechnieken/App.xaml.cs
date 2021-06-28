using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HerexamenGevorderdeProgrammeertechnieken.ViewModels;
using HerexamenGevorderdeProgrammeertechnieken;

namespace HerexamenGevorderdeProgrammeertechnieken
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            MainViewModel mainViewModel = new MainViewModel();
            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();
        }
    }
}
