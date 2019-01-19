using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TDEE
{
    class GoalPageViewModel : INotifyPropertyChanged
    {
        public double GoalWeight
        {
            get
            {
                return UserSettings.GoalWeight;
            }
            set
            {
                UserSettings.GoalWeight = value;
                OnPropertyChanged("GoalWeight");
            }
        }

        public double GoalRate
        {
            get
            {
                return UserSettings.GoalRate;
            }
            set
            {
                UserSettings.GoalRate = value;
                OnPropertyChanged("GoalRate");
            }
        }


        public GoalPageViewModel()
        {

        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
