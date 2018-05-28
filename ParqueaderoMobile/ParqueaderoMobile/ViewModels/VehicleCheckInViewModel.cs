namespace ParqueaderoMobile.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Models.Models;
    using BusinessLayer.Helpers;
    using BusinessLayer.BusinessLogic;
    using BusinessLayer.Interfaces;

    public class VehicleCheckInViewModel : BaseViewModel
    {
        #region Attributes
        private string licencePlate;
        private int displacement;
        private IVehicleBusinessLogic vehicleBusinessLogic;
        private Vehicle vehicle;
        private bool isVisibleDisplacement;
        #endregion

        #region Propertie
        public string LicencePlate
        {
            get
            {
                return this.licencePlate;
            }
            set
            {
                SetValue(ref this.licencePlate, value);
            }
        }
        public int Displacement
        {
            get
            {
                return this.displacement;
            } set
            {
                SetValue(ref this.displacement, value);
            }
        }
        public bool IsVisibleDisplacement
        {  
            get
            {
                return this.isVisibleDisplacement;
            }
            set
            {
                SetValue(ref this.isVisibleDisplacement, value);
            }
        }
        #endregion

        #region Constructors
        public VehicleCheckInViewModel(string vehicleType)
        {
            this.vehicleBusinessLogic = new VehicleBusinessLogic();
            this.vehicle = new Vehicle();
            this.vehicle.VehicleType = vehicleType;
            isVisibleDisplacement = VehicleBLHelper.IsMotorcycle(this.vehicle);
        }
        #endregion

        #region Methods
        private async void CheckInVehicle()
        {
            vehicle.Displacement = this.displacement;
            vehicle.LicencePlate = this.licencePlate;
            var response = await vehicleBusinessLogic.CheckInVehicle(vehicle);
            string alertTitle = response.IsSuccess ? "Correcto" : "Error";
            await Application.Current.MainPage.DisplayAlert(
                   alertTitle,
                   response.Message,
                   "Aceptar");
            await Application.Current.MainPage.Navigation.PopAsync();
            return;

        }
        #endregion

        #region Commands
        public ICommand CheckInVehicleCommand
        {
            get
            {
                return new RelayCommand(CheckInVehicle);
            }
        }
        #endregion
    }
}
