using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eat2fitDesktop.Services;
using eat2fitDesktop.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eat2fitDesktop.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateFoodPage : ContentPage
	{
		async void OnCreateFoodClicked(object sender, EventArgs e)
		{
			int cal = -1;
			try
			{
				cal = Convert.ToInt32(calories.Text);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
			Food food = new Food();
			food.Name = name.Text;
			food.Calories = cal;
			var mongoService = new MongoService();

			try
			{
				await mongoService.CreateFood(food);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
			await Navigation.PopAsync();
		}
		public CreateFoodPage ()
		{
			InitializeComponent ();
		}
	}
}