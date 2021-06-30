using HerexamenGevorderdeProgrammeertechnieken.Navigatie;
using HerexamenGevorderdeProgrammeertechnieken.ViewModels;
using HerexamenGevorderdeProgrammeertechnieken.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HerexamenGevorderdeProgrammeertechnieken.Services
{
    public class SecondWindowService
    {
        private static Window Window;
        public ICommand SetViewModel => UpdateViewModel.Navigate.SetViewModel;
        public void OpenWindow(string view)
        {
            CloseWindow();
            Window = new SecondWindow() { DataContext = new SecondWindowViewModel() };
            Window.Show();
            SetViewModel.Execute(view);

        }

        public void CloseWindow()
        {
            if (Window != null)
            {
                Window.Close();
            }

        }
    }
}
