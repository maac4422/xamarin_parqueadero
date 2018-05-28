namespace BusinessLayer.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BusinessLayer.Helpers;
    using BusinessLayer.Interfaces;
    using Models.Models;
    using ServiceAccessLayer.Interfaces;
    using ServiceAccessLayer.Services;

    public class VehicleBusinessLogic : IVehicleBusinessLogic
    {
        #region Attributes
        private IVehicleServices vehicleServices;
        #endregion

        #region Contructors
        public VehicleBusinessLogic()
        {
            vehicleServices = new VehicleServices();
        }
        public VehicleBusinessLogic(IVehicleServices vehicleServices)
        {
            this.vehicleServices = vehicleServices;
        }
        #endregion

        #region Private Methods
        private async Task<Response> GetActiveCars()
        {
            var response = await vehicleServices.GetCars();
            return response;
        }

        private async Task<Response> GetActiveMotorcycles()
        {
            var response = await vehicleServices.GetMotorcycles();
            return response;
        }
        #endregion

        #region Inferface Methods
        

        public async Task<Response> GetAllActiveVehicles(string vehicleType)
        {
            Response response;
            if (VehicleBLHelper.IsCar(vehicleType))
            {
                response = await GetActiveCars();
            }
            else
            {
                response = await GetActiveMotorcycles();
            }
            return response;
        }

        public async Task<Response> CheckInVehicle(Vehicle vehicle)
        {
            var response = await vehicleServices.CheckInVehicle(vehicle);
            return response;
        }

        public async Task<Response> CheckOutVehicle(Vehicle vehicle)
        {
            var response = await vehicleServices.CheckOutVehicle(vehicle);
            return response;
           
        }

        #endregion
    }
}
