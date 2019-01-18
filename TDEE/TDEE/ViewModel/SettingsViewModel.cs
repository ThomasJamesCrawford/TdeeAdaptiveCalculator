using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TDEE.ViewModel
{
    class SettingsViewModel : INotifyPropertyChanged
    {

        public bool Metric
        {
            get
            {
                return UserSettings.Metric;
            }
            set
            {
                UserSettings.Metric = value;
                OnPropertyChanged("Metric");
                OnPropertyChanged("CaloriesPerUnit");
            }
        }

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

        public int WeeksInAvg
        {
            get
            {
                return UserSettings.WeeksInAvg;
            }
            set
            {
                UserSettings.WeeksInAvg = value;
                OnPropertyChanged("WeeksInAvg");
            }
        }

        public double CaloriesPerUnit
        {
            get
            {
                return UserSettings.CaloriesPerUnit;
            }
            set
            {
                UserSettings.CaloriesPerUnit = value;
                OnPropertyChanged("CaloriesPerUnit");
            }
        }

        public SettingsViewModel()
        {
            Metric = UserSettings.Metric;
            GoalWeight = UserSettings.GoalWeight;
            WeeksInAvg = UserSettings.WeeksInAvg;
            CaloriesPerUnit = UserSettings.CaloriesPerUnit;
        }

        public ICommand ResetDefaults => new Command(() => ClearUserSettings());

        private void ClearUserSettings()
        {
            UserSettings.ClearAllData();
            OnPropertyChanged("CaloriesPerUnit");
            OnPropertyChanged("WeeksInAvg");
            OnPropertyChanged("GoalWeight");
            OnPropertyChanged("Metric");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
