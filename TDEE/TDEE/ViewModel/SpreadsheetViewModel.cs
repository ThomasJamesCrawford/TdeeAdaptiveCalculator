using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TDEE
{
    class SpreadsheetViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TodoItem> _items;
        public ObservableCollection<TodoItem> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        private TodoItem _selectedItem;
        public TodoItem SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
                OnPropertyChanged("ItemSelected");
            }
        }

        public ICommand Delete => new Command(() => DeleteSelectedItem());

        public ICommand Save => new Command(() => SaveSelectedItem());


        private void DeleteSelectedItem()
        {
            if (_selectedItem != null)
            {
                Task<int> task = Task.Run(() => AsyncDeleteSelectedItem());
                int r = task.Result;
                App.UpdateItems();
                RefreshItems();
                SelectedItem = null;
            }
        }

        private void SaveSelectedItem()
        {
            if (_selectedItem != null)
            {
                Task<int> task = Task.Run(() => AsyncSaveSelectedItem());
                int r = task.Result;
                RefreshItems();
                SelectedItem = null;
            }
        }

        public string WeightPlaceholder
        {
            get
            {
                return UserSettings.Metric ? "KGS" : "LBS";
            }
        }

        public bool ItemSelected
        {
            get
            {
                return SelectedItem != null;
            }
        }

        private async Task<int> AsyncSaveSelectedItem()
        {
            return await App.Database.SaveCompleteItemAsync(SelectedItem);
        }

        private async Task<int> AsyncDeleteSelectedItem()
        {
            return await App.Database.DeleteItemAsync(SelectedItem);
        }

        public SpreadsheetViewModel()
        {
            RefreshItems();
            SelectedItem = null;
        }

        private void RefreshItems()
        {
            ObservableCollection<TodoItem> items = new ObservableCollection<TodoItem>();
            App.Items.ForEach((i) =>
            {
                items.Insert(0, i);
            });

            Items = items;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
