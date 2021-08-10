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
        public string GeldactiviteitId { get; set; }
        public ObservableCollection<Geldactiviteit> Geldactiviteiten { get; set; }

        //geselecteerde geldactiviteit uit datagrid
        private Geldactiviteit _selectedGeldactiviteit;
        public Geldactiviteit SelectedGeldactiviteit
        {
            get { return _selectedGeldactiviteit; }
            set
            {
                _selectedGeldactiviteit = value;
                GeldactiviteitRecordInstellen();
                //NotifyPropertyChanged("SelectedGeldactiviteit");
                //NotifyPropertyChanged(); //omdat er gewerkt wordt met nuget package Propertychanged.Fody hoeft dit niet meer

            }
        }

        public UserControlHomeViewModel()
        {
            Geldactiviteiten = new ObservableCollection<Geldactiviteit>(unitOfWork.GeldactiviteitRepo.Ophalen(x => x.GeldactiviteitId));
            GeldactiviteitRecordInstellen();
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
            int i = int.Parse(GeldactiviteitId);
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
                FoutmeldingInstellenNaSave(ok, "Orderlijn is niet verwijderd");

               
            }
            else
            {
                Foutmelding = "Eerst Orderlijn selecteren";
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
