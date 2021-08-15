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
    /// Interaction logic for UserControlHome.xaml
    /// </summary>
    public partial class UserControlHome : UserControl
    {
        private UserControlHomeViewModel controlHomeViewModel;

        public UserControlHome()
        {
            InitializeComponent();
            controlHomeViewModel = new UserControlHomeViewModel();
            base.DataContext = controlHomeViewModel;
            datagrid.DataContext = controlHomeViewModel.getActiviteiten();
            datagrid.SelectedValuePath = "Id";
        }
    }
}
