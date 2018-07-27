using System;
using System.Collections.Generic;
using System.Text;
using eat2fit.Models;
using eat2fit.Services;
using Xamarin.Forms;

namespace eat2fitDesktop.ViewModels
{
    public class AddFoodVM
    {
		Food food = new Food();
		public string Calories { get; set; }
		public string Name { get; set; }

		public Command OnAddFoodClickedCommand { get; }
		async void OnAddFoodClicked()
		{
			if (Name == null || Calories == null)
			{
				System.Diagnostics.Debug.WriteLine("name or cal not set");
				//TODO: diplay alert: Please complete all fields
			}
			else
			{
				int cal;
				food.Name = Name;
				try
				{
					cal = Convert.ToInt32(Calories);
					food.Calories = cal;
					var mongoService = new MongoService();
					await mongoService.CreateFood(food);
					await Application.Current.MainPage.Navigation.PopAsync();


				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.Message);
				}

			
			}
		}

		public AddFoodVM()
		{
			OnAddFoodClickedCommand = new Command(OnAddFoodClicked);
		}
	}
}
