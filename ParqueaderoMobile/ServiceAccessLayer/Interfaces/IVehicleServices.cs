namespace ServiceAccessLayer.Interfaces
{
    using Models.Models;
    using System.Threading.Tasks;

    public interface IVehicleServices
    {
        Task<Response> GetVehicle(int id);

        Task<Response> GetVehicles();

        Task<Response> GetCars();

        Task<Response> GetMotorcycles();

        Task<Response> CheckInVehicle(Vehicle vehicle);

        Task<Response> CheckOutVehicle(Vehicle vehicle);
    }
}
