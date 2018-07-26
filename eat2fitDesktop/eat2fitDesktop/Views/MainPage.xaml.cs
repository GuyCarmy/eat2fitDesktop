using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using eat2fitDesktop.Models;
using eat2fitDesktop.Services;
using System.Windows.Input;
using eat2fitDesktop.Views;
using eat2fitDesktop.ViewModels;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;

namespace eat2fitDesktop.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		
		protected override void OnAppearing()
		{
			base.OnAppearing();
			var vm = BindingContext as MainPageVM;
			vm.GetCustomers();

		}
		public MainPage()
		{
			InitializeComponent();
			BindingContext = new MainPageVM();





		}
	
	}
}
