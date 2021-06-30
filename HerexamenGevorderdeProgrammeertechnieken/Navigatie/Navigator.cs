using HerexamenGevorderdeProgrammeertechnieken.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HerexamenGevorderdeProgrammeertechnieken.Navigatie;

namespace HerexamenGevorderdeProgrammeertechnieken.Navigatie
{
    class Navigator : INavigator, INotifyPropertyChanged
    {
        public BasisViewModel CurrentMainViewModel { get; set; }
        public BasisViewModel CurrentSecondViewModel { get; set; }

        public ICommand SetViewModel => new UpdateViewModel();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
