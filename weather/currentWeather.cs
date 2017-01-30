using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace weather
{
    class currentWeather: INotifyPropertyChanged
    {
        private City currentCity;
        public City CurrentCity
        {
            get
            {
                return currentCity;
            }
            set
            {
                currentCity = value;
                OnPropertyChanged("CurrentCity");
            }
        }
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
