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
using eat2fitDesktop.Pages;

namespace eat2fitDesktop
{
	public partial class MainPage : ContentPage
	{
		MongoService mongoService = new MongoService();
		List<Customer> customers = new List<Customer>();

		async void GetCustomers()
		{
			customers = await mongoService.GetAllCustomers();
			CustomerPicker.Items.Clear();
			foreach (Customer c in customers)
			{
				CustomerPicker.Items.Add(c.ToString());
			}

		}
		async void OnNewCustomerClick(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AddCostumerPage());
		}
		async void OnAddMealClick(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AddMealPage());
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			GetCustomers();

		}
		public MainPage()
		{
			InitializeComponent();
			





		}
	
	}
}
