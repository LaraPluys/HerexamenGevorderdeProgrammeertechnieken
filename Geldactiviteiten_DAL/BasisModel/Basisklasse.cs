using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Geldactiviteiten_DAL.BasisModel
{
    public abstract class Basisklasse : IDataErrorInfo, INotifyPropertyChanged
    {
        public string this[string columnName] => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsGeldig()
        {
            return string.IsNullOrWhiteSpace(Error);

        }
        public string Error
        {
            get
            {
                string foutmeldingen = "";

                foreach (var item in this.GetType().GetProperties(BindingFlags.DeclaredOnly)) //reflection 
                {

                    string fout = this[item.Name];
                    if (!string.IsNullOrWhiteSpace(fout))
                    {
                        foutmeldingen += fout + Environment.NewLine;
                    }

                }
                return foutmeldingen;
            }
        }
    }
}
