using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using eat2fitDesktop.Models;
using eat2fitDesktop.Services;
using System.Diagnostics;
using System.Windows.Input;



namespace eat2fitDesktop
{
	public partial class MainPage : ContentPage
	{
		MongoService mongoService = new MongoService();
		List<Customer> customers = new List<Customer>();
		List<Customer> customersTests = new List<Customer>();

		async void getCustomers()
		{
			Customer c = new Customer();
			customers = await mongoService.GetAllCustomers();

		}
		async void onNewCustomerClick(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AddCostumerPage());
		}
		public MainPage()
		{
			InitializeComponent();
			getCustomers();
			ActualIntakeList.ItemsSource = customers;
			foreach (Customer c in customersTests)
			{
				CustomerPicker.Items.Add(c.name);
			}





		}
	
	}
}
