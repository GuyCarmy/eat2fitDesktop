using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using eat2fitDesktop.Models;
using eat2fitDesktop.Services;
using System.Windows.Input;
using eat2fitDesktop.Views;
using eat2fitDesktop.ViewModels;
using System.Collections.ObjectModel;

namespace eat2fitDesktop
{
	public partial class MainPage : ContentPage
	{
		MongoService mongoService = new MongoService();
		List<Customer> customers = new List<Customer>();
		AddMealVM addMealVM;
		AddMealPage addMealPage;
		async void GetCustomers()
		{
			try
			{
				customers = await mongoService.GetAllCustomers();
				CustomerPicker.ItemsSource = new ObservableCollection<Customer>(customers);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}

		}
		async void OnNewCustomerClick(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AddCustomerPage());
		}
		async void OnAddMealClick(object sender, EventArgs e)
		{
			if (CustomerPicker.SelectedItem != null)
			{

				addMealVM = new AddMealVM();
				addMealVM.SetCustomer(CustomerPicker.SelectedItem);
				addMealPage = new AddMealPage
				{
					BindingContext = addMealVM
				};
				await Navigation.PushAsync(addMealPage);
			}else
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
