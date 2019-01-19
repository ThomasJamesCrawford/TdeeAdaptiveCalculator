using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Xamarin.Forms;

namespace TDEE
{
    public class MainPageCS : MasterDetailPage
    {
        MasterPageCS masterPage;

        public MainPageCS()
        {
            masterPage = new MasterPageCS();
            Master = masterPage;
            Detail = new NavigationPage(new AddData());
            MasterBehavior = MasterBehavior.Popover;

            masterPage.ListView.ItemSelected += OnItemSelected;
        }

        void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                try
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    masterPage.ListView.SelectedItem = null;
                    IsPresented = false;
                } catch(TargetInvocationException tie)
                {
                    Console.WriteLine(tie.GetBaseException().ToString());
                    Console.WriteLine(tie.GetBaseException().GetBaseException().ToString());
                    Console.WriteLine(tie.GetBaseException().GetBaseException().GetBaseException().ToString());


                }

            }
        }
    }
}