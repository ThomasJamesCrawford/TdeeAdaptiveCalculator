using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDEE.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TDEE.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Settings : ContentPage
	{
		public Settings ()
		{
			InitializeComponent ();
            BindingContext = new SettingsViewModel();
		}
	}
}