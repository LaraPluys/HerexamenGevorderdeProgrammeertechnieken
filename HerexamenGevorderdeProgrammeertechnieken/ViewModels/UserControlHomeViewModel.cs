using Geldactiviteiten_DAL.Data;
using Geldactiviteiten_DAL.Data.UnitOfWork;
using Geldactiviteiten_DAL.Models;
using HerexamenGevorderdeProgrammeertechnieken.Navigatie;
using HerexamenGevorderdeProgrammeertechnieken.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HerexamenGevorderdeProgrammeertechnieken.ViewModels
{
    public class UserControlHomeViewModel : BasisViewModel, IDisposable
    {
        public INavigator Navigate => UpdateViewModel.Navigate;
        public ICommand SetViewModel => UpdateViewModel.Navigate.SetViewModel;
        public override string this[string columnName] => throw new NotImplementedException();

        private SecondWindowService SWS = new SecondWindowService();

        IUnitOfWork unitOfWork = new UnitOfWork(new GeldactiviteitEntities());
        public Geldactiviteit GeldactiviteitRecord { get; set; }
        public string Foutmelding { get; set; }
        public string GeldactiviteitID { get; set; }
        public ObservableCollection<Geldactiviteit> Geldactiviteiten { get; set; }
        public ObservableCollection<Soort> Soorten { get; set; }
        public ObservableCollection<GeldactivietenSoorten> GeldList { get; set; }

        //geselecteerde geldactiviteit uit datagrid
        private Geldactiviteit _selectedGeldactiviteit;
        public Geldactiviteit SelectedGeldactiviteit
        {
            get { return _selectedGeldactiviteit; }
            set
            {
                _selectedGeldactiviteit = value;
                GeldactiviteitRecordInstellen();
            }
        }

        public UserControlHomeViewModel()
        {
            Geldactiviteiten = new ObservableCollection<Geldactiviteit>(unitOfWork.GeldactiviteitRepo.Ophalen());
            Soorten = new ObservableCollection<Soort>();
        }

        public List<GeldactivietenSoorten> getActiviteiten()
        {
            var data = unitOfWork.GeldactiviteitRepo.Ophalen().Join(unitOfWork.SoortRepo.Ophalen(), ga => ga.SoortId, so => so.SoortId, (ga, so) => new
            {
                Id = ga.GeldactiviteitId,
                Naam = ga.Naam,
                Beschrijving = ga.Omschrijving,
                ToDo = ga.ToDo,
                Soort = so.Naam,
                Wanneer = ga.Wanneer,
                Kosten = ga.Kosten,
                Inkomsten = ga.Inkomsten
            }).ToList();

            List<GeldactivietenSoorten> GeldList = new List<GeldactivietenSoorten>();

            foreach (var d in data)
            {
                GeldList.Add(new GeldactivietenSoorten { Id = d.Id.ToString(), Naam = d.Naam, Beschrijving = d.Beschrijving, ToDo = d.ToDo, Soort = d.Soort, Kosten = d.Kosten, Inkomsten = d.Inkomsten, Wanneer = d.Wanneer });
            }

            return GeldList;
        }

        public void EditActiviteit()
        {
            if (SelectedGeldactiviteit != null)
            {
                if (GeldactiviteitRecord.IsGeldig())
                {
                    unitOfWork.GeldactiviteitRepo.ToevoegenOfAanpassen(GeldactiviteitRecord);
                    int ok = unitOfWork.Save();

                    FoutmeldingInstellenNaSave(ok, "Geldactiviteit is niet aangepast");
                }
            }
            else
            {
                Foutmelding = "Selecteer een geldactiviteit!";
            }
        }


        private void RefreshGeldactiviteiten()
        {
            int i = int.Parse(GeldactiviteitID);
            List<Geldactiviteit> listGeldactiviteiten = unitOfWork.GeldactiviteitRepo.Ophalen(x => x.GeldactiviteitId == i).ToList();

            Geldactiviteiten = new ObservableCollection<Geldactiviteit>(listGeldactiviteiten);
        }

        private void FoutmeldingInstellenNaSave(int ok, string melding)
        {
            if (ok > 0)
            {
                RefreshGeldactiviteiten();
                Resetten();
            }
            else
            {
                Foutmelding = melding;
            }
        }

        public void Resetten()
        {
            if (this.IsGeldig())
            {
                SelectedGeldactiviteit = null;
                GeldactiviteitRecordInstellen();
                Foutmelding = "";
            }
            else
            {
                Foutmelding = this.Error;
            }
        }

        public void DeleteActiviteit()
        {
            if (SelectedGeldactiviteit != null)
            {
                
                unitOfWork.GeldactiviteitRepo.Verwijderen(SelectedGeldactiviteit.GeldactiviteitId);
                int ok = unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "activiteit is niet verwijderd");

               
            }
            else
            {
                Foutmelding = "Eerst acitiviteit selecteren";
            }
        }

        private void GeldactiviteitRecordInstellen()
        {
            if (SelectedGeldactiviteit != null)
            {
                GeldactiviteitRecord = SelectedGeldactiviteit;
                
            }
            else
            {
                GeldactiviteitRecord = new Geldactiviteit();
                
            }
        }

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
                    EditActiviteit();
                    break;
                case "DeleteActiviteit":
                    DeleteActiviteit();
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
