using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HerexamenGevorderdeProgrammeertechnieken.ViewModels;
using HerexamenGevorderdeProgrammeertechnieken;
using HerexamenGevorderdeProgrammeertechnieken.Windows;

namespace HerexamenGevorderdeProgrammeertechnieken
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
         protected override void OnStartup(StartupEventArgs e)
        {
            Window MainWindow = new MainWindow();
            MainWindow.DataContext = new MainWindowViewModel();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
