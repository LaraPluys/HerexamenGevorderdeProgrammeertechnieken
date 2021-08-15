using Geldactiviteiten_DAL.Data;
using Geldactiviteiten_DAL.Data.UnitOfWork;
using Geldactiviteiten_DAL.Models;
using HerexamenGevorderdeProgrammeertechnieken.Navigatie;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Doelpubliek> DoelPubliekItem { get; set; }
        public string DoelPubliekNaam { get; set; }

        IUnitOfWork unitOfWork = new UnitOfWork(new GeldactiviteitEntities());

        public override string this[string columnName] => throw new NotImplementedException();

        public UserControlBeheerDoelpubliekViewModel()
        {
            LoadDoelPubliek();
        }

        public void LoadDoelPubliek()
        {
            DoelPubliekItem = new ObservableCollection<Doelpubliek>(unitOfWork.DoelpubliekRepo.Ophalen());
        }

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

        public void Toevoegen()
        {
            Doelpubliek doelpubliek = new Doelpubliek();
            doelpubliek.Naam = DoelPubliekNaam;
            unitOfWork.DoelpubliekRepo.Toevoegen(doelpubliek);
            LoadDoelPubliek();
            DoelPubliekNaam = "";
        }
    }
}
