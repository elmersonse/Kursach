using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Kursach
{
    class ViewModel : INotifyPropertyChanged
    {
        private int _selectedIndexA = -1;
        private int _selectedIndexB = -1;
        public int SelectedIndexA
        {
            get { return _selectedIndexA; }
            set
            {
                _selectedIndexA = value;
                _selectedIndexB = -1;
                OnPropertyChanged("SelectedIndexB");
            }
        }

        public int SelectedIndexB
        {
            get { return _selectedIndexB; }
            set
            {
                _selectedIndexB = value;
                _selectedIndexA = -1;
                OnPropertyChanged("SelectedIndexA");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
