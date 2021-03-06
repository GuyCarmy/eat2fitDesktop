﻿using eat2fit.Models;
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
    public class AddMealVM : INotifyPropertyChanged
    {
		Meal meal = new Meal();
		MongoService mongoService = new MongoService();
		ObservableCollection<Food> foods = new ObservableCollection<Food>();
		public ObservableCollection<Food> Foods
		{
			get => foods;
			set
			{
				foods = value;
				OnPropertyChanged();
			}
		}
		public ObservableCollection<Food> ThisMealFoods {
			get
			{
				return new ObservableCollection<Food>(meal.Foods);
			}
		}

		private Customer Customer;

		public string Hrs { get; set; }
		public string Mins { get; set; }
		private string search;
		public string Search { get => search;
			set
			{
				search = value.ToLower();
				UpdateFoodList();
			}
		}
		public string  Amount { get; set; }
		public object SelectedFood { get; set; }

		public void SetCustomer(object c)
		{
			if (c is Customer)
			{
				Customer = c as Customer;
			}
			else
			{
				System.Diagnostics.Debug.WriteLine("c is not Customer"); //todo raise exception
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		public Command OnNewFoodClickedCommand { get; }
		async void OnNewFoodClicked()
		{
			await Application.Current.MainPage.Navigation.PushAsync(new AddFoodPage());
		}

		public Command OnCreateMealClickedCommand { get; }
		async void OnCreateMealClicked()
		{

			if (Hrs == null || Mins == null)
			{
				System.Diagnostics.Debug.WriteLine("hrs or mins was not inserted");
				await Application.Current.MainPage.DisplayAlert("Missing Field", "Please Enter Time", "Ok");
			}
			else
			{
				try
				{
					int hrs = Convert.ToInt32(Hrs);
					int mins = Convert.ToInt32(Mins);
					meal.Time = hrs * 60 + mins;
					//add meal to customer
					Customer.AddSuggestedMeal(meal);
					//send customer using mongoservice
					await mongoService.EditCustomer(Customer);
					await Application.Current.MainPage.Navigation.PopAsync();
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.Message);
				}

				
			}
		}

		public Command OnAddFoodToMealClickedCommand { get; }
		async void OnAddFoodToMealClicked()
		{
			int amount = 0;
			Food food = null;
			if (SelectedFood == null || Amount == null)
			{
				System.Diagnostics.Debug.WriteLine("food was not selected or amount was not inserted");
				await Application.Current.MainPage.DisplayAlert("Missing Field", "Please Select Food and Enter Amount", "Ok");
			}
			else
			{
				food = SelectedFood as Food;
				try
				{
					amount = Convert.ToInt32(Amount);
					food.Amount = amount;
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.Message);
				}
				meal.Foods.Add(food);
				OnPropertyChanged("ThisMealFoods");
			}
		}

		public async void UpdateFoodList()
		{
			System.Diagnostics.Debug.WriteLine("Update Food List was called");
			try
			{
				var foo = await mongoService.GetAllFoods();
				if(Search != null)
				{
					foo = foo.FindAll(x => x.Name.Contains(Search));
				}
				Foods = new ObservableCollection<Food>(foo);

			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}

		}


		public AddMealVM()
		{
			OnNewFoodClickedCommand = new Command(OnNewFoodClicked);
			OnCreateMealClickedCommand = new Command(OnCreateMealClicked);
			OnAddFoodToMealClickedCommand = new Command(OnAddFoodToMealClicked);
		}
	}
}
