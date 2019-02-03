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
                if (MyDouble.TryParse0(value, out double d))
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
                if (MyDouble.TryParse0(value, out double d))
                {
                    UserSettings.GoalRate = d;
                    SetGoals();
                }

                _goalRate = value;
            }
        }

        private string _surplus;
        public string Surplus
        {
            get
            {
                return _surplus;
            }
            set
            {
                if (MyDouble.TryParse0(value, out double d))
                {
                    UserSettings.GoalRate = d * 7.0 / UserSettings.CaloriesPerUnit;
                    SetGoals();
                }

                _surplus = value;
            }
        }

        public bool PlaceholderUnit
        {
            get => UserSettings.Metric;
        }

        public GoalPageViewModel()
        {
            GoalRate = UserSettings.GoalRate == 0 ? "" : UserSettings.GoalRate.ToString();
            GoalWeight = UserSettings.GoalWeight > 0 ? UserSettings.GoalWeight.ToString() : "";
            Surplus = Math.Round(UserSettings.GoalRate * UserSettings.CaloriesPerUnit / 7) == 0 ? "" : Math.Round(UserSettings.GoalRate * UserSettings.CaloriesPerUnit / 7).ToString();
        }

        private void SetGoals()
        {
            _goalRate = UserSettings.GoalRate == 0 ? "" : UserSettings.GoalRate.ToString();
            _surplus = Math.Round(UserSettings.GoalRate * UserSettings.CaloriesPerUnit / 7) == 0 ? "" : Math.Round(UserSettings.GoalRate * UserSettings.CaloriesPerUnit / 7).ToString();
            OnPropertyChanged("Surplus");
            OnPropertyChanged("GoalRate");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = "") => 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
