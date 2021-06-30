using HerexamenGevorderdeProgrammeertechnieken.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HerexamenGevorderdeProgrammeertechnieken.Navigatie
{
    public interface INavigator
    {
        BasisViewModel CurrentMainViewModel { get; set; }
        BasisViewModel CurrentSecondViewModel { get; set; }

        ICommand SetViewModel { get; }
    }
}
