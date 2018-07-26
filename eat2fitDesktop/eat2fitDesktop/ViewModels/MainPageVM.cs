using eat2fitDesktop.Models;
using eat2fitDesktop.Services;
using eat2fitDesktop.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace eat2fitDesktop.ViewModels
{
    public class MainPageVM : INotifyPropertyChanged
	{
		object SelectedCustomer { get; set; }
		MongoService mongoService = new MongoService();
		private ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
		public ObservableCollection<Customer> Customers
		{
			get => customers;
			set
			{
				customers = value;
				OnPropertyChanged();
			}
		}
		private ObservableCollection<Meal> suggestedDiet = new ObservableCollection<Meal>();
		public ObservableCollection<Meal> SuggestedDiet
		{
			get => suggestedDiet;
			set
			{
				suggestedDiet = value;
				OnPropertyChanged();
			}
		}
		private ObservableCollection<Meal> eatedDiet = new ObservableCollection<Meal>();
		public ObservableCollection<Meal> EatedDiet
		{
			get => eatedDiet;
			set
			{
				eatedDiet = value;
				OnPropertyChanged();
			}
		}
		AddMealVM addMealVM;
		AddMealPage addMealPage;

		public event PropertyChangedEventHandler PropertyChanged;
		void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		public async void GetCustomers()
		{
			System.Diagnostics.Debug.WriteLine("got to get customers"); //todo delete
			try
			{
				Customers = new ObservableCollection<Customer>(await mongoService.GetAllCustomers());
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}

		}

		public Command OnNewCustomerClickedCommand { get; }
		async void OnNewCustomerClicked()
		{
			System.Diagnostics.Debug.WriteLine("new customer was clicked"); //todo delete
 			await Application.Current.MainPage.Navigation.PushAsync(new AddCustomerPage());
		}

		public Command OnAddMealClickedCommand { get; }
		async void OnAddMealClicked()
		{
			if (SelectedCustomer != null)
			{

				addMealVM = new AddMealVM();
				addMealVM.SetCustomer(SelectedCustomer);
				addMealPage = new AddMealPage
				{
					BindingContext = addMealVM
				};
				await Application.Current.MainPage.Navigation.PushAsync(addMealPage);
			}
			else
				System.Diagnostics.Debug.WriteLine("didnt selecet customer");
				//todo await DisplayAlert("No Customer", "Please select a customer first", "OK");
		}

		public MainPageVM()
		{
			System.Diagnostics.Debug.WriteLine("main page view model created"); //todo delete
			OnAddMealClickedCommand = new Command(OnAddMealClicked);
			OnNewCustomerClickedCommand = new Command(OnNewCustomerClicked);
		}
	}
}
