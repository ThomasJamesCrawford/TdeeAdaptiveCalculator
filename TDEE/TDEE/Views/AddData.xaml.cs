using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace TDEE
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddData : ContentPage
	{
		public AddData()
		{
            InitializeComponent();
            BindingContext = new AddDataPageViewModel();
        }
    }
}