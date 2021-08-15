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
    public class UserControlBeheerDoelViewModel : BasisViewModel
    {
        public override string this[string columnName] => throw new NotImplementedException();

        public INavigator Navigate => UpdateViewModel.Navigate;

        public ObservableCollection<Doel> DoelItem { get; set; }
        public string DoelNaam { get; set; }

        IUnitOfWork unitOfWork = new UnitOfWork(new GeldactiviteitEntities());

        public UserControlBeheerDoelViewModel()
        {
            LoadDoel();
        }

        public void LoadDoel()
        {
            DoelItem = new ObservableCollection<Doel>(unitOfWork.DoelRepo.Ophalen());
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
            Doel doel = new Doel();
            doel.Naam = DoelNaam;
            unitOfWork.DoelRepo.Toevoegen(doel);
            LoadDoel();
            DoelNaam = "";
        }
    }
}
