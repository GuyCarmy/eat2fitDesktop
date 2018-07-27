
using eat2fit.Models;
using eat2fit.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace eat2fitDesktop.ViewModels
{
    public class AddCustomerVM
    {
		Customer customer = new Customer();
		public string Name { get; set; }
		public string Age { get; set; }
		public string Password { get; set; }
		

		public Command OnAddCustomerClickedCommand { get; }
		async void OnAddCustomerClicked()
		{
			customer.Name = Name;
			customer.Password = Password;
			try
			{
				customer.Age = Convert.ToInt32(Age);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
			var mongoService = new MongoService();
			await mongoService.CreateCustomer(customer);
			await Application.Current.MainPage.Navigation.PopAsync();
		}

		public AddCustomerVM()
		{
			OnAddCustomerClickedCommand = new Command(OnAddCustomerClicked);
		}
	}
}

