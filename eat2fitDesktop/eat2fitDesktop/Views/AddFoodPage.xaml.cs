using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eat2fitDesktop.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eat2fitDesktop.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddFoodPage : ContentPage
	{

		public AddFoodPage ()
		{
			InitializeComponent ();
			BindingContext = new AddFoodVM();
		}
	}
}