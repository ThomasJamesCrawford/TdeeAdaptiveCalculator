using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TDEE
{
    class AddDataPageViewModel : INotifyPropertyChanged
    {
        private string _labelText;
        public string LabelText
        {
            get
            {
                return _labelText;
            }
            set
            {
                _labelText = value;
                OnPropertyChanged("LabelText");
            }
        }

        private string _cal;
        public string Cal
        {
            get
            {
                return _cal;
            }
            set
            {
                _cal = value;
                OnPropertyChanged("Cal");
            }
        }

        private string _weight;
        public string Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
                OnPropertyChanged("Weight");
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        private string _weightPlaceholder;
        public string WeightPlaceholder
        {
            get
            {
                return _weightPlaceholder;
            }
            set
            {
                _weightPlaceholder = value;
                OnPropertyChanged("WeightPlaceholder");
            }
        }

        public AddDataPageViewModel()
        {
            Date = DateTime.Now;
            LabelText = Tdee_Math.Get_Tdee().ToString();
            WeightPlaceholder = UserSettings.Metric ? "KGS" : "LBS";
        }

        public ICommand SubmitCommand => new Command(() => AddToDatabase());

        private async void AddToDatabase()
        {
            try
            {
                double.TryParse(Weight, out double w);
                double.TryParse(Cal, out double c);

                await App.Database.SaveItemAsync(
                    new TodoItem()
                    {
                        Weight = w,
                        Calories = c,
                        Date = Date
                    });

                App.UpdateItems();
                LabelText = Tdee_Math.Get_Tdee().ToString();
                Weight = "";
                Cal = "";
                
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
