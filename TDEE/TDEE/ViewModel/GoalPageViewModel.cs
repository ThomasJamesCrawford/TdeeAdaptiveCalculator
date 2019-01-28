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
        private string _goalWeight;
        public string GoalWeight
        {
            get
            {
                return _goalWeight;
            }
            set
            {
                if (MyDouble.TryParse(value, out double d))
                {
                    UserSettings.GoalWeight = d;
                    OnPropertyChanged("GoalWeight");
                }

                _goalWeight = value;
            }
        }

        private string _goalRate;
        public string GoalRate
        {
            get
            {
                return _goalRate;
            }
            set
            {
                if (MyDouble.TryParse(value, out double d))
                {
                    UserSettings.GoalRate = d;
                    OnPropertyChanged("GoalRate");
                }

                _goalRate = value;
            }
        }

        public bool PlaceholderUnit
        {
            get => UserSettings.Metric;
        }

        public GoalPageViewModel()
        {
            GoalRate = UserSettings.GoalRate.ToString();
            GoalWeight = UserSettings.GoalWeight.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = "") => 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
