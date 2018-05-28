namespace ParqueaderoMobile.Views
{
    using ParqueaderoMobile.Interfaces;
    using ParqueaderoMobile.ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarsPage : ContentPage
	{
		public CarsPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var viewmodel = MainViewModel.GetInstance().Cars;
            if (viewmodel != null)
            {
                 viewmodel.OnAppearing();
            }
        }


    }
}