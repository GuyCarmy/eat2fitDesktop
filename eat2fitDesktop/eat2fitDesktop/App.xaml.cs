using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using eat2fitDesktop.Views;
using eat2fitDesktop.ViewModels;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace eat2fitDesktop
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
			var p = new MainPage();
			var vm = new MainPageVM();
			p.BindingContext = vm;
			MainPage = new NavigationPage(p);
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
