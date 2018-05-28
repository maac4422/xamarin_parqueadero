namespace ParqueaderoMobile.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models.Models;
    using System.Windows.Input;
    using ServiceAccessLayer.Interfaces;
    using ServiceAccessLayer.Services;
    using Xamarin.Forms;
    using BusinessLayer.Helpers;
    using ParqueaderoMobile.Constants;

    public class VehicleViewModel : BaseViewModel
    {
        #region Attributes
        private IVehicleServices vehicleServices;
        #endregion

        #region Properties
        public Vehicle Vehicle { get; set; }
        public string VehicleType
        {
            get
            {
                return VehicleBLHelper.IsCar(this.Vehicle) ? "Carro" : "Moto";
            }
        }
        #endregion

        #region Contructors
        public VehicleViewModel(Vehicle vehicle)
        {
            this.vehicleServices = new VehicleServices();
            this.Vehicle = vehicle;
        }
        #endregion

        #region Methods
        public async void CheckOutVehicle()
        {
            var response = await vehicleServices.CheckOutVehicle(this.Vehicle);
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
                   "Correcto",
                   string.Format("{0} ${1}",MessageConstants.VehicleCheckOut, vehicleResponse.Payment),
                   "Aceptar");
            await Application.Current.MainPage.Navigation.PopAsync();
            return;
        }
        #endregion

        #region Commands
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
