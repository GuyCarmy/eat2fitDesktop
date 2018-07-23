using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eat2fitDesktop.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddMealPage : ContentPage
	{
		async void OnNewFoodClicked(object sender ,EventArgs e)
		{
			await Navigation.PushAsync(new CreateFoodPage());
		}
		async void OnCreateMealClicked(object sender, EventArgs e)
		{

		}
		public AddMealPage ()
		{
			InitializeComponent ();
		}
	}
}