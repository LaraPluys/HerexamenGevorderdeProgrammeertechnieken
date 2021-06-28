using System;
using HerexamenGevorderdeProgrammeertechnieken;
using Geldactiviteiten_DAL.Data;
using Geldactiviteiten_DAL.Data.UnitOfWork;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Geldactiviteiten_DAL.Models;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace HerexamenGevorderdeProgrammeertechnieken.ViewModels
{
   public class MainViewModel : BasisViewModel, IDisposable
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new GeldactiviteitEntities());

        private BasisViewModel _selectedViewModel = new HomeViewModel();

        public BasisViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { _selectedViewModel = value; }
        }

        public ICommand UpdateViewCommand { get; set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
