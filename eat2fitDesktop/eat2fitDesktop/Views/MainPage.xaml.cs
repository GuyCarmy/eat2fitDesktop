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
using eat2fitDesktop.Views;
using eat2fitDesktop.ViewModels;

namespace eat2fitDesktop
{
	public partial class MainPage : ContentPage
	{
		AddCustomerVM addCustomerVM = new AddCustomerVM();
		MongoService mongoService = new MongoService();
		List<Customer> customers = new List<Customer>();

		async void GetCustomers()
		{
			customers = await mongoService.GetAllCustomers();
			CustomerPicker.Items.Clear();
			foreach (Customer c in customers)
			{
				CustomerPicker.Items.Add(c.Name);
			}

		}
		async void OnNewCustomerClick(object sender, EventArgs e)
		{
			AddCustomerPage p = new AddCustomerPage();
			p.BindingContext = addCustomerVM;
			await Navigation.PushAsync(p);
		}
		async void OnAddMealClick(object sender, EventArgs e)
		{
			if (CustomerPicker.SelectedItem != null)
				//set CustomerPcicker selected item somewhere
				await Navigation.PushAsync(new AddMealPage());
			else
				await DisplayAlert("No Customer", "Please select a customer first", "OK");
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
