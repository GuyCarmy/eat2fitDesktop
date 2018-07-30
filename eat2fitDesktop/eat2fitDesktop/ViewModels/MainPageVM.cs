using eat2fit.Models;
using eat2fit.Services;
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
		//todo: bug- if you add meal for a customer, when it goes back to the main page the customer doesnt show.
		private Customer selectedCustomer;
		public Customer SelectedCustomer
		{
			get
			{
				return selectedCustomer;
			}
			set
			{
				if (value is Customer)
				{
					selectedCustomer = value as Customer;
					CustomerChanged();
				}
				else
				{

					System.Diagnostics.Debug.WriteLine("value is not Customer");
					//raise exception

				}
				OnPropertyChanged();
			}
		}

		public string SelectedCustomerString { get; set; }
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

		public async void RefreshMainPage()
		{
			try
			{
				Customers = new ObservableCollection<Customer>(await mongoService.GetAllCustomers());
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}

		}

		void CustomerChanged()
		{
			System.Diagnostics.Debug.WriteLine("customer changed to: " + selectedCustomer); 
			try
			{
				SelectedCustomerString = SelectedCustomer.Name +", "+ SelectedCustomer.Details; //todo change the style (in xaml) to something more fit
				OnPropertyChanged("SelectedCustomerString");
				SuggestedDiet = new ObservableCollection<Meal>(selectedCustomer.SuggestedDiet);
				EatedDiet = new ObservableCollection<Meal>(selectedCustomer.EatedDiet);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
		}

		public Command OnNewCustomerClickedCommand { get; }
		async void OnNewCustomerClicked()
		{
			System.Diagnostics.Debug.WriteLine("selected customer is: " + SelectedCustomer);
			System.Diagnostics.Debug.WriteLine("new customer was clicked");
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
			{
				System.Diagnostics.Debug.WriteLine("didnt selecet customer");
				await Application.Current.MainPage.DisplayAlert("Missing Field", "Please Select Customer First", "Ok");
			}
		}

		public MainPageVM()
		{
			OnAddMealClickedCommand = new Command(OnAddMealClicked);
			OnNewCustomerClickedCommand = new Command(OnNewCustomerClicked);
		}
	}
}
