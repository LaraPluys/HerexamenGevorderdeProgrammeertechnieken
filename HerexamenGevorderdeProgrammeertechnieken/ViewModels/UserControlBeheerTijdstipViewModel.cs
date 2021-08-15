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

namespace HerexamenGevorderdeProgrammeertechnieken.ViewModels
{
    public class UserControlBeheerTijdstipViewModel : BasisViewModel
    {
        public INavigator Navigate => UpdateViewModel.Navigate;
        public override string this[string columnName] => throw new NotImplementedException();

        public ObservableCollection<Tijdstip> TijdstipItem { get; set; }
        public string TijdstipNaam { get; set; }

        IUnitOfWork unitOfWork = new UnitOfWork(new GeldactiviteitEntities());

        public UserControlBeheerTijdstipViewModel()
        {
            LoadTijdstip();
        }

        public void LoadTijdstip()
        {
            TijdstipItem = new ObservableCollection<Tijdstip>(unitOfWork.TijdstipRepo.Ophalen());
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
            Tijdstip tijdstip = new Tijdstip();
            tijdstip.Naam = TijdstipNaam;
            unitOfWork.TijdstipRepo.Toevoegen(tijdstip);
            LoadTijdstip();
            TijdstipNaam = "";
        }
    }
}
