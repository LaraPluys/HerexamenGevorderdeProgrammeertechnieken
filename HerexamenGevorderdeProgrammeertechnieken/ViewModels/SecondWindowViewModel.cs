using HerexamenGevorderdeProgrammeertechnieken.Navigatie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerexamenGevorderdeProgrammeertechnieken.ViewModels
{
    public class SecondWindowViewModel : BasisViewModel
    {
        public override string this[string columnName] => throw new NotImplementedException();

        public INavigator Navigate => UpdateViewModel.Navigate;

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
