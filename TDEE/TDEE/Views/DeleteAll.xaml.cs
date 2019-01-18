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
	public partial class DeleteAll : ContentPage
	{
		public DeleteAll ()
		{
			InitializeComponent ();
            BindingContext = new DeleteAllViewModel(this);
		}
    }
}