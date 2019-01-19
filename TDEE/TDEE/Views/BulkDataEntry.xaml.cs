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
	public partial class BulkDataEntry : ContentPage
	{
		public BulkDataEntry ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string text = this.TextBox.Text;
            DateTime dateWeight = this.DatePicker.Date.AddDays(-1);
            DateTime dateCal = this.DatePicker.Date.AddDays(-1);


            if (text == null)
                return;

            string[] s = text.Split(default(char[])); // splits on space

            int count = 0; 
            foreach(string a in s)
            {
                double tmp;
                double.TryParse(a, out tmp);

                if ((count/7)%2 != 0)
                {
                    dateCal = dateCal.AddDays(1);
                    double cal = 0;
                    double.TryParse(a, out cal);
                    await App.Database.SaveItemAsync(new TodoItem(0, cal, dateCal));
                }
                else
                {
                    dateWeight = dateWeight.AddDays(1);
                    double weight = 0;
                    double.TryParse(a, out weight);
                    await App.Database.SaveItemAsync(new TodoItem(weight, 0, dateWeight));
                }
                count++;
            }

            
        }
    }
}