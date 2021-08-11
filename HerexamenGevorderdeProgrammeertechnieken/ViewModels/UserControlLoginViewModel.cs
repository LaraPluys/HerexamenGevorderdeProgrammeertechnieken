using HerexamenGevorderdeProgrammeertechnieken.Navigatie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HerexamenGevorderdeProgrammeertechnieken.ViewModels
{
    public class UserControlLoginViewModel : BasisViewModel
    {
        public INavigator Navigate => UpdateViewModel.Navigate;

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                NotifyPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyPropertyChanged();
            }
        }

        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Login":
                    this.Login();
                    break;
            }
        }

        public void Login()
        {
            MessageBox.Show($"Username: {this.Username}\nPassword: {this.Password}", "Info",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }       
    }
}
