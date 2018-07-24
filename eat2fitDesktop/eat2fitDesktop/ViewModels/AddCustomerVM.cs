using eat2fitDesktop.Models;
using eat2fitDesktop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace eat2fitDesktop.ViewModels
{
    public class AddCustomerVM : INotifyPropertyChanged
    {
		Customer customer = new Customer();
		public Command OnAddCustomerClickedCommand { get; }
		public string Name { get; set; }
		public string Age { get; set; }
		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
		async void OnAddCustomerClicked()
		{
			customer.Name = Name;
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
			//TODO: pop the page when finish
			//await Navigation.PopAsync();
		}
		public AddCustomerVM()
		{
			OnAddCustomerClickedCommand = new Command(OnAddCustomerClicked);
		}
	}
}

//TODO: Add ViewModels to all pages and bind all
//example: https://github.com/jamesmontemagno/TheXamarinShow/blob/master/2016-10-05%20Episode%205%20MVVM/ContactsApp/ContactsApp/ViewModels/AddContactViewModel.cs
//TODO: 
