using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eat2fitDesktop.Models;
using eat2fitDesktop.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eat2fitDesktop.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddMealPage : ContentPage
	{
		MongoService mongoService = new MongoService();
		List<Food> foods = new List<Food>();
		Customer customer = null;

		async void OnNewFoodClicked(object sender ,EventArgs e)
		{
			await Navigation.PushAsync(new CreateFoodPage());
		}
		async void OnCreateMealClicked(object sender, EventArgs e)
		{

		}
		async void OnAddFoodToMealClicked(object sender, EventArgs e)
		{
			int amount = 0;
			Food food = null;

			try
			{
				amount = Convert.ToInt32(amountEntry.Text);
				food = FoodsList.SelectedItem as Food;
				food.Amount = amount;
				
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
		

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