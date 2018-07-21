using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eat2fitDesktop
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCostumerPage : ContentPage
	{
		void onAddCustomerClicked(object sender, EventArgs e)
		{

			Navigation.PopAsync();
		}
		public AddCostumerPage ()
		{
			InitializeComponent ();
		}

	}
}