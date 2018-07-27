using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eat2fit.Services;
using eat2fit.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using eat2fitDesktop.ViewModels;

namespace eat2fitDesktop
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCustomerPage : ContentPage
	{
		
		public AddCustomerPage ()
		{
			InitializeComponent ();
			BindingContext = new AddCustomerVM();
		}

	}
}