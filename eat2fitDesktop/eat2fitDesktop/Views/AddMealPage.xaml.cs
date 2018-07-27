using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eat2fit.Models;
using eat2fit.Services;
using eat2fitDesktop.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eat2fitDesktop.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddMealPage : ContentPage
	{
		protected override void OnAppearing()
		{
			base.OnAppearing();
			var vm = BindingContext as AddMealVM;
			vm.UpdateFoodList();
		}
		public AddMealPage ()
		{
			InitializeComponent ();
		}
	}
}