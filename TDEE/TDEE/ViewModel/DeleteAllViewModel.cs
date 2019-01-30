using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TDEE
{
    class DeleteAllViewModel 
    {
        public ContentPage Owner { get; set; }

        public ICommand DeleteAll => new Command(() => DeleteAllData());

        public DeleteAllViewModel(ContentPage cp)
        {
            Owner = cp;
        }

        private async void DeleteAllData()
        {
            var action = await Owner.DisplayAlert("Delete All", "Are you sure you want to delete ALL data?", "Delete All", "Cancel");

            if (action)
            {
                await App.Database.DeleteAll();
            }
        }


    }
}
