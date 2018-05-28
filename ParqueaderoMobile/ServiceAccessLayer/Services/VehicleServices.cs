namespace ServiceAccessLayer.Services
{
    using System.Threading.Tasks;
    using Interfaces;
    using Models.Models;
    using Models.Enumerators;
    using Constants;

    public class VehicleServices : IVehicleServices
    {
        private ApiServices apiServices;

        public VehicleServices()
        {
            this.apiServices = new ApiServices();
        }

        public async Task<Response> GetCars()
        {
            var customParams = "vehicle?type=" + VehicleEnumerator.VehicleTypes.car.ToString();
            var response = await apiServices.GetList<Vehicle>(
                ServiceConstants.UrlBase,
                ServiceConstants.ServisePrefix,
                EndPointConstants.Vehicles,
                customParams);
            return response;
        }

        public async Task<Response> GetMotorcycles()
        {
            var customParams = "vehicle?type=" + VehicleEnumerator.VehicleTypes.motorcycle.ToString();
            var response = await apiServices.GetList<Vehicle>(
                ServiceConstants.UrlBase,
                ServiceConstants.ServisePrefix,
                EndPointConstants.Vehicles,
                customParams);
            return response;
        }

        public async Task<Response> GetVehicle(int id)
        {
            var response = await apiServices.Get<Vehicle>(
                ServiceConstants.UrlBase,
                ServiceConstants.ServisePrefix,
                EndPointConstants.Vehicles, id);
            return response;
        }

        public async Task<Response> GetVehicles()
        {
            var response = await apiServices.GetList<Vehicle>(
                ServiceConstants.UrlBase,
                ServiceConstants.ServisePrefix,
                EndPointConstants.Vehicles);
            return response;
        }

        public async Task<Response> CheckInVehicle(Vehicle vehicle)
        {
            var response = await apiServices.Post(
                ServiceConstants.UrlBase,
                ServiceConstants.ServisePrefix,
                EndPointConstants.Vehicles,
                vehicle);
            return response;
        }

        public async Task<Response> CheckOutVehicle(Vehicle vehicle)
        {
            var response = await apiServices.Put(
                ServiceConstants.UrlBase,
                ServiceConstants.ServisePrefix,
                EndPointConstants.Vehicles,
                vehicle,
                vehicle.Id);
            return response;
        }
    }
}
