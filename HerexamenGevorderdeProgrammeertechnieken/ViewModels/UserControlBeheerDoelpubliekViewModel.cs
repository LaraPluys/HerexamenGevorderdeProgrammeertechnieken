using HerexamenGevorderdeProgrammeertechnieken.Navigatie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HerexamenGevorderdeProgrammeertechnieken.ViewModels
{
    public class UserControlBeheerDoelpubliekViewModel : BasisViewModel
    {
        public INavigator Navigate => UpdateViewModel.Navigate;
        public ICommand SetViewModel => UpdateViewModel.Navigate.SetViewModel;

        public override string this[string columnName] => throw new NotImplementedException();

        public override bool CanExecute(object parameter)
        {
            switch (parameter)
            {
                default:
                    return false;
                case "Toevoegen":
                    return true;
                
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter)
            {
                case "Toevoegen":
                    Toevoegen();
                    break;

            }
        }
        
        public void Toevoegen() { }
    }
}
