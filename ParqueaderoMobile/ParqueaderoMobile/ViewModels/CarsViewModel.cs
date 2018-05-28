namespace ParqueaderoMobile.ViewModels
{   
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;
    using ParqueaderoMobile.Interfaces;
    using Models.Models;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using ParqueaderoMobile.Views;
    using Models.Enumerators;
    using ParqueaderoMobile.Helpers;
    using BusinessLayer.Interfaces;
    using BusinessLayer.BusinessLogic;

    public class CarsViewModel : BaseViewModel, IPageLifeCylceEvents
    {
        #region Attributes
        private ObservableCollection<VehicleItemViewModel> vehicles;
        private IVehicleBusinessLogic vehicleBusinessLogic;
        private List<Vehicle> vehiclesList;
        private bool isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<VehicleItemViewModel> Vehicles {
            get
            {
                return this.vehicles;
            }
            set
            {
                SetValueCollection(ref this.vehicles, value);
            }
        }

        public bool IsRefreshing {
            get
            {
                return this.isRefreshing;
            }
            set
            {
                SetValue(ref this.isRefreshing, value);
            }
        }
        
        #endregion

        #region Constructors
        public CarsViewModel()
        {
            this.vehicleBusinessLogic = new VehicleBusinessLogic();
        }
        #endregion

        #region Methods
        private async void LoadCars() {
            var response =  await this.vehicleBusinessLogic.GetAllActiveVehicles(VehicleEnumerator.VehicleTypes.car.ToString());
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
                return;
            }
            this.vehiclesList = (List<Vehicle>)response.Result;
            this.Vehicles = new ObservableCollection<VehicleItemViewModel>(
                VehicleHelper.ToVehicleItemViewModel(this.vehiclesList)
            );
            this.IsRefreshing = false;
        }

        private async void RedirectToVehicleCheckIn()
        {
            MainViewModel.GetInstance().VehicleCheckIn = new VehicleCheckInViewModel(VehicleEnumerator.VehicleTypes.car.ToString());
            await Application.Current.MainPage.Navigation.PushAsync(new VehicleCheckInPage());
        }

        public void RemoveItem(VehicleItemViewModel vehicleItemViewModel)
        {
            this.Vehicles.Remove(vehicleItemViewModel);
        }

        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadCars);
            }
        }

        public ICommand AddCarCommand {
            get
            {
                return new RelayCommand(RedirectToVehicleCheckIn);
            }
        }
        #endregion

        #region Events
        public  void OnAppearing()
        {
            LoadCars();
        }

        public void OnDisappearing()
        {
        }
        #endregion

    }
}
