﻿using Geldactiviteiten_DAL.Data;
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
        public string GeldactiviteitId { get; set; }
        public ObservableCollection<Geldactiviteit> Geldactiviteiten { get; set; }

        private SecondWindowService SWS = new SecondWindowService();

        public override bool CanExecute(object parameter)
        {
            switch (parameter)
            {
                default:
                    return false;
                case "Reset":
                    return true;
                case "Opslaan&Sluiten":
                    return true;
                case "Opslaan&Nieuw":
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
            
        }

        public void OpslaanSluiten()
        {
            if (this.IsGeldig())
            {
                GeldactiviteitRecord.GeldactiviteitId = int.Parse(GeldactiviteitId);
                if (GeldactiviteitRecord.IsGeldig())
                {
                    unitOfWork.GeldactiviteitRepo.Toevoegen(GeldactiviteitRecord);
                    int ok = unitOfWork.Save();
                }
                else
                {
                    Foutmelding = "Geldaciviteit is niet toegevoegd";
                }
            }
            
            SWS.CloseWindow();
        }

        public void OpslaanNieuw()
        {
            if (this.IsGeldig())
            {
                GeldactiviteitRecord.GeldactiviteitId = int.Parse(GeldactiviteitId);
                if (GeldactiviteitRecord.IsGeldig())
                {
                    unitOfWork.GeldactiviteitRepo.Toevoegen(GeldactiviteitRecord);
                    int ok = unitOfWork.Save();
                }
                else
                {
                    Foutmelding = "Geldaciviteit is niet toegevoegd";
                }
            }

            Reset();
        }

         
    }
}
