using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eat2fitDesktop
{
	public partial class MainPage : ContentPage
	{
		async void onNewCustomerClick(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AddCostumerPage());
		}
		public MainPage()
		{
			InitializeComponent();
		}
	}
}
