using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eat2fitDesktop.Services;
using eat2fitDesktop.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eat2fitDesktop
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCostumerPage : ContentPage
	{
		async void onAddCustomerClicked(object sender, EventArgs e)
		{
			Customer customer = new Customer();
			customer.name = name.Text;
			customer.age = Convert.ToInt32( age.Text);
			var mongoService = new MongoService();
			await mongoService.CreateCustomer(customer);
			await Navigation.PopAsync();
		}
		public AddCostumerPage ()
		{
			InitializeComponent ();
		}

	}
}