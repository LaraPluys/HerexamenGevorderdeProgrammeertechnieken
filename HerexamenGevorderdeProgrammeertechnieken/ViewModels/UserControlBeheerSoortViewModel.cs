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
    public class UserControlBeheerSoortViewModel : BasisViewModel
    {
        public INavigator Navigate => UpdateViewModel.Navigate;
        public ObservableCollection<Soort> SoortItem { get; set; }
        public string SoortNaam { get; set; }

        IUnitOfWork unitOfWork = new UnitOfWork(new GeldactiviteitEntities());
        public override string this[string columnName] => throw new NotImplementedException();

        public UserControlBeheerSoortViewModel()
        {
            LoadSoort();
        }

        public void LoadSoort()
        {
            SoortItem = new ObservableCollection<Soort>(unitOfWork.SoortRepo.Ophalen());
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
            Soort soort = new Soort();
            soort.Naam = SoortNaam;
            unitOfWork.SoortRepo.Toevoegen(soort);
            LoadSoort();
        }
    }
}
