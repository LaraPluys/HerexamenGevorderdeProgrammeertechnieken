using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xaml;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HerexamenGevorderdeProgrammeertechnieken.Components;

namespace HerexamenGevorderdeProgrammeertechnieken.Views
{
    /// <summary>
    /// Interaction logic for UserControlLogin.xaml
    /// </summary>
    public partial class UserControlLogin : UserControl
    {
        public UserControlLogin()
        {
            InitializeComponent();
            HerexamenGevorderdeProgrammeertechnieken.Components.BindablePasswordBox bpb = new BindablePasswordBox();
            this.gridLogin.Children.Add(bpb);
        }
    }
}
