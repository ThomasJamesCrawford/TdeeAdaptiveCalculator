﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TDEE.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Goal : ContentPage
	{
		public Goal ()
		{
			InitializeComponent ();
            BindingContext = new GoalPageViewModel();
		}
	}
}