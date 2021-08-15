using Geldactiviteiten_DAL.Data;
using Geldactiviteiten_DAL.Data.UnitOfWork;
using Geldactiviteiten_DAL.Models;
using Geldactiviteiten_DAL.BasisModel;
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
    public class UserControlActiviteitToevoegenViewModel : BasisViewModel
    {
        public INavigator Navigate => UpdateViewModel.Navigate;
        public ICommand SetViewModel => UpdateViewModel.Navigate.SetViewModel;
        public override string this[string columnName] => throw new NotImplementedException();

        IUnitOfWork unitOfWork = new UnitOfWork(new GeldactiviteitEntities());
        public Geldactiviteit GeldactiviteitRecord { get; set; }
        public string Foutmelding { get; set; }
        public int GeldactiviteitID { get; set; }
        public ObservableCollection<Geldactiviteit> Geldactiviteiten { get; set; }
        public ObservableCollection<Soort> SoortItem { get; set; }
        public ObservableCollection<Doel> DoelItem { get; set; }
        public ObservableCollection<Doelpubliek> DoelpubliekItem { get; set; }
        public ObservableCollection<Tijdstip> TijdstipItem { get; set; }

        public Geldactiviteit_Doel geldactiviteit_Doelen { get; set; }
        public Geldactiviteit_Doelpubliek geldactiviteit_Doelpublieken { get; set; }
        public Geldactiviteit_Tijdstip geldactiviteit_Tijdstippen { get; set; }


        private SecondWindowService SWS = new SecondWindowService();

        public string GeldActiviteitNaam { get; set; }
        public string GeldNaam { get; set; }
        public string Besch { get; set; }
        public string ToDo { get; set; }
        public string Kosten { get; set; }
        public string Inkomsten { get; set; }
        public string Wanneer { get; set; }
        public ObservableCollection<Soort> SoortIds { get; set; }
        public ObservableCollection<Doel> DoelIds { get; set; }
        public ObservableCollection<Doelpubliek> DoelpubliekIds { get; set; }
        public ObservableCollection<Tijdstip> TijdstipIds { get; set; }


        public UserControlActiviteitToevoegenViewModel()
        {
            LoadMasters();
        }

        public void LoadMasters()
        {
            SoortItem = new ObservableCollection<Soort>(unitOfWork.SoortRepo.Ophalen());
            DoelItem = new ObservableCollection<Doel>(unitOfWork.DoelRepo.Ophalen());
            DoelpubliekItem = new ObservableCollection<Doelpubliek>(unitOfWork.DoelpubliekRepo.Ophalen());
            TijdstipItem = new ObservableCollection<Tijdstip>(unitOfWork.TijdstipRepo.Ophalen());
            SoortIds = new ObservableCollection<Soort>();
            DoelIds = new ObservableCollection<Doel>();
            DoelpubliekIds = new ObservableCollection<Doelpubliek>();
            TijdstipIds = new ObservableCollection<Tijdstip>();
        }


        public override bool CanExecute(object parameter)
        {
            switch (parameter)
            {
                default:
                    return false;
                case "Reset":
                    return true;
                case "OpslaanSluiten":
                    return true;
                case "OpslaanNieuw":
                    return true;
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter)
            {
                case "Reset":
                    Reset();
                    break;
                case "OpslaanSluiten":
                    OpslaanSluiten();
                    break;
                case "OpslaanNieuw":
                    OpslaanNieuw();
                    break;

            }
        }

        public void Reset()
        {
            GeldNaam = ""; Besch = ""; Kosten = ""; Inkomsten = ""; Wanneer = ""; ToDo = "";
        }

        public void OpslaanSluiten()
        {


            saveRecord();

            SWS.CloseWindow();
        }

        public void OpslaanNieuw()
        {
            saveRecord();

            Reset();
        }

        private void saveRecord()
        {
            try
            {
                GeldactiviteitRecord = new Geldactiviteit();
                GeldactiviteitRecord.Inkomsten = Inkomsten;
                GeldactiviteitRecord.Kosten = Kosten;
                GeldactiviteitRecord.Omschrijving = Besch;
                GeldactiviteitRecord.SoortId = SoortIds[0].SoortId;
                GeldactiviteitRecord.ToDo = ToDo;
                GeldactiviteitRecord.Wanneer = Wanneer;
                GeldactiviteitRecord.Naam = GeldNaam;


                unitOfWork.GeldactiviteitRepo.Toevoegen(GeldactiviteitRecord);
                GeldactiviteitID = GeldactiviteitRecord.GeldactiviteitId;

                for (int i = 0; i <= DoelIds.Count - 1; i++)
                {
                    geldactiviteit_Doelen = new Geldactiviteit_Doel();
                    geldactiviteit_Doelen.DoelId = DoelIds[i].DoelId;
                    geldactiviteit_Doelen.GeldactiviteitId = GeldactiviteitID;
                    unitOfWork.Geldactiviteit_DoelRepo.Toevoegen(geldactiviteit_Doelen);
                    int geldDoelID = geldactiviteit_Doelen.Geldactiviteit_DoelId;
                }

                for (int i = 0; i <= DoelpubliekIds.Count - 1; i++)
                {
                    geldactiviteit_Doelpublieken = new Geldactiviteit_Doelpubliek();
                    geldactiviteit_Doelpublieken.DoelpubliekId = DoelpubliekIds[i].DoelpubliekId;
                    geldactiviteit_Doelpublieken.GeldactiviteitId = GeldactiviteitID;
                    unitOfWork.Geldactiviteit_DoelpubliekRepo.Toevoegen(geldactiviteit_Doelpublieken);
                    int geldDoepublieklID = geldactiviteit_Doelpublieken.Geldactiviteit_DoelpubliekId;
                }

                for (int i = 0; i <= TijdstipIds.Count - 1; i++)
                {
                    geldactiviteit_Tijdstippen = new Geldactiviteit_Tijdstip();
                    geldactiviteit_Tijdstippen.TijdstipId = TijdstipIds[i].TijdstipId;
                    geldactiviteit_Tijdstippen.GeldactiviteitId = GeldactiviteitID;
                    unitOfWork.Geldactiviteit_TijdstipRepo.Toevoegen(geldactiviteit_Tijdstippen);
                    int geldTijID = geldactiviteit_Tijdstippen.Geldactiviteit_TijdstipId;
                }
            }
            catch (Exception e)
            {
                Foutmelding = "Geldactiviteit is niet toegevoegd";
            }
        }



    }
}
