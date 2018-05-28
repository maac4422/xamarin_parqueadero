namespace ParqueaderoMobile.ViewModels{

    using BusinessLayer.BusinessLogic;
    using BusinessLayer.Interfaces;
    using GalaSoft.MvvmLight.Command;
    using Models.Models;
    using ParqueaderoMobile.Constants;
    using BusinessLayer.Helpers;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class VehicleItemViewModel : Vehicle
    {

        #region Attributes
        private IVehicleBusinessLogic vehicleBusinessLogic;
        #endregion

        #region Constructors
        public VehicleItemViewModel()
        {
            this.vehicleBusinessLogic = new VehicleBusinessLogic();
        }
        #endregion

        #region Methods
        private async void SelectVehicle()
        {
            MainViewModel.GetInstance().Vehicle = new VehicleViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new VehiclePage());
        }

        private async void CheckOutVehicle()
        {
            var response = await vehicleBusinessLogic.CheckOutVehicle(this);
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
                return;
            }
            Vehicle vehicleResponse = (Vehicle)response.Result;
            await Application.Current.MainPage.DisplayAlert(
                   "Retiro Correcto",
                   string.Format("{0} ${1}", MessageConstants.VehicleCheckOut, vehicleResponse.Payment),
                   "Aceptar");
            RemoveItem();
            return;
        }

        private void RemoveItem()
        {
            
            if (VehicleBLHelper.IsMotorcycle(this))
            {
                RemoveMotorcycleItem();
            }
            else
            {
                RemoveCarItem();
            }
        }

        private void RemoveMotorcycleItem()
        {
            var viewModel =  MainViewModel.GetInstance().Motorcycles;
            if (viewModel != null)
            {
                viewModel.RemoveItem(this);
            }
        }

        private void RemoveCarItem()
        {
            var viewModel = MainViewModel.GetInstance().Cars;
            if (viewModel != null)
            {
                viewModel.RemoveItem(this);
            }
        }
        #endregion

        #region Commands
        public ICommand SelectVehicleCommand
        {
            get
            {
                return new RelayCommand(SelectVehicle);
            }
        }
        public ICommand CheckOutVehicleCommand
        {
            get
            {
                return new RelayCommand(CheckOutVehicle);
            }
        }
        #endregion
    }
}
