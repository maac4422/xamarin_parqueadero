namespace ParqueaderoMobile.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using ParqueaderoMobile.Interfaces;
    using ParqueaderoMobile.ViewModels;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MotorcyclesPage : ContentPage
	{
		public MotorcyclesPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var viewmodel = MainViewModel.GetInstance().Motorcycles;
            if (viewmodel != null)
            {
                viewmodel.OnAppearing();
            }
        }
    }
}