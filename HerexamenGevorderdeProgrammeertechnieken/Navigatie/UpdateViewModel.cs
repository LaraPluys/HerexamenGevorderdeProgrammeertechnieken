using HerexamenGevorderdeProgrammeertechnieken.ViewModels;
using HerexamenGevorderdeProgrammeertechnieken.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HerexamenGevorderdeProgrammeertechnieken.Navigatie
{
    public class UpdateViewModel : ICommand
    {
        public static INavigator Navigate { get; set; } = new Navigator();

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            switch (parameter)
            {
                default:
                    return false;

                //voor mainwindow
                case "UserControlActiviteitToevoegen":
                    return true;
                case "UserControlHome":
                    return true;

                //voor second window
                case "UserControlBeheerDoelpubliek":
                    return true;
                case "UserControlBeheerDoel":
                    return true;
                case "UserControlBeheerSoort":
                    return true;
                case "UserControlBeheerTijdstip":
                    return true;
                case "UserControlLogin":
                    return true;

            }
        }

        public void Execute(object parameter)
        {
            switch (parameter)
            {

                //voor mainwindow
                case "UserControlActiviteitToevoegen":
                    Navigate.CurrentMainViewModel = new UserControlActiviteitToevoegenViewModel();
                    break;
                case "UserControlHome":
                    Navigate.CurrentMainViewModel = new UserControlHomeViewModel();
                    break;

                //voor second window
                case "UserControlBeheerDoelpubliek":
                    Navigate.CurrentSecondViewModel = new UserControlBeheerDoelpubliekViewModel();
                    break;
                case "UserControlBeheerDoel":
                    Navigate.CurrentSecondViewModel = new UserControlBeheerDoelViewModel();
                    break;
                case "UserControlBeheerSoort":
                    Navigate.CurrentSecondViewModel = new UserControlBeheerSoortViewModel();
                    break;
                case "UserControlBeheerTijdstip":
                    Navigate.CurrentSecondViewModel = new UserControlBeheerTijdstipViewModel();
                    break;
                case "UserControlLogin":
                    Navigate.CurrentSecondViewModel = new UserControlLoginViewModel();
                    break;

            }
        }
    }
}
