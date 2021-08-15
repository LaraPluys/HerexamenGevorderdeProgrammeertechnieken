using Geldactiviteiten_DAL.Models;
using HerexamenGevorderdeProgrammeertechnieken.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HerexamenGevorderdeProgrammeertechnieken.Views
{
    /// <summary>
    /// Interaction logic for UserControlActiviteitToevoegen.xaml
    /// </summary>
    public partial class UserControlActiviteitToevoegen : UserControl
    {
        UserControlActiviteitToevoegenViewModel ControlActiviteitToevoegenViewModel;
        public UserControlActiviteitToevoegen()
        {
            InitializeComponent();
            ControlActiviteitToevoegenViewModel = new UserControlActiviteitToevoegenViewModel();
            base.DataContext = ControlActiviteitToevoegenViewModel;
        }

        private void soortList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            ControlActiviteitToevoegenViewModel.SoortIds.Clear();
            foreach (Soort soort in item.SelectedItems)
            {
                ControlActiviteitToevoegenViewModel.SoortIds.Add(soort);
            }

        }

        private void doelList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            ControlActiviteitToevoegenViewModel.DoelIds.Clear();
            foreach (Doel doel in item.SelectedItems)
            {
                ControlActiviteitToevoegenViewModel.DoelIds.Add(doel);
            }
        }

        private void TijdstipList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            ControlActiviteitToevoegenViewModel.TijdstipIds.Clear();
            foreach (Tijdstip tij in item.SelectedItems)
            {
                ControlActiviteitToevoegenViewModel.TijdstipIds.Add(tij);
            }
        }

        private void doelpubliekList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            ControlActiviteitToevoegenViewModel.DoelpubliekIds.Clear();
            foreach (Doelpubliek doelpub in item.SelectedItems)
            {
                ControlActiviteitToevoegenViewModel.DoelpubliekIds.Add(doelpub);
            }
        }
    }
}
