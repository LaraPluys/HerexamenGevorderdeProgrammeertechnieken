using HerexamenGevorderdeProgrammeertechnieken.Navigatie;
using HerexamenGevorderdeProgrammeertechnieken.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HerexamenGevorderdeProgrammeertechnieken.ViewModels
{
    public class UserControlHomeViewModel : BasisViewModel
    {
        public INavigator Navigate => UpdateViewModel.Navigate;
        public ICommand SetViewModel => UpdateViewModel.Navigate.SetViewModel;
        public override string this[string columnName] => throw new NotImplementedException();

        private SecondWindowService SWS = new SecondWindowService();

        public override bool CanExecute(object parameter)
        {
            switch (parameter)
            {
                default:
                    return false;
                case "NieuweActiviteit":
                    return true;
                case "EditActiviteit":
                    return true;
                case "DeleteActiviteit":
                    return true;
                case "BeheerSoort":
                    return true;
                case "BeheerDoelpubliek":
                    return true;
                case "BeheerDoel":
                    return true;
                case "BeheerTijdstip":
                    return true;
                case "Login":
                    return true;
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter)
            {
                case "NieuweActiviteit":
                    SetViewModel.Execute("UserControlActiviteitToevoegen");
                    break;

                case "EditActiviteit":

                    break;
                case "DeleteActiviteit":

                    break;
                case "BeheerSoort":
                    SWS.OpenWindow("UserControlBeheerSoort");
                    break;
                case "BeheerDoelpubliek":
                    SWS.OpenWindow("UserControlBeheerDoelpubliek");
                    break;
                case "BeheerDoel":
                    SWS.OpenWindow("UserControlBeheerDoel");
                    break;
                case "BeheerTijdstip":
                    SWS.OpenWindow("UserControlBeheerTijdstip");
                    break;
                case "Login":
                    SWS.OpenWindow("UserControlLogin");
                    break;
            }
        }
    }
}
