using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
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

        public SpreadsheetViewModel()
        {
            Items = new ObservableCollection<TodoItem>();
            App.Items.ForEach((i) =>
            {
                Items.Insert(0, i);
            });


        }
        public ICommand Delete => new Command((sender) => _delete((MenuItem)sender));

        private void _delete(MenuItem i)
        {
            Console.WriteLine("gggggggg");

            Console.WriteLine(i.CommandParameter);
            Console.WriteLine(i);

            Console.WriteLine("gggggggg");

        }

        public ICommand Edit => new Command((sender) => _edit((MenuItem)sender));

        private void _edit(MenuItem i)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
