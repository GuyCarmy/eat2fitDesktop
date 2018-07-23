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
			Food food = new Food
			{
				Name = name.Text,
				Calories = Convert.ToInt32(calories.Text)
			};
			var mongoService = new MongoService();
			await mongoService.CreateFood(food);
			await Navigation.PopAsync();
		}
		public CreateFoodPage ()
		{
			InitializeComponent ();
		}
	}
}