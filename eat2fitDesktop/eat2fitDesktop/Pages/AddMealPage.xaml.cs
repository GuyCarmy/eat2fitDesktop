using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eat2fitDesktop.Models;
using eat2fitDesktop.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eat2fitDesktop.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddMealPage : ContentPage
	{
		MongoService mongoService = new MongoService();
		List<Food> foods = new List<Food>();

		async void OnNewFoodClicked(object sender ,EventArgs e)
		{
			await Navigation.PushAsync(new CreateFoodPage());
		}
		async void OnCreateMealClicked(object sender, EventArgs e)
		{

		}
		async void UpdateFoodsList()
		{

			foods = await mongoService.GetAllFoods();
			FoodsList.ItemsSource = foods;
		
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			UpdateFoodsList();
		}
		public AddMealPage ()
		{
			InitializeComponent ();
			
		}
	}
}