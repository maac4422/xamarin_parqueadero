namespace BusinessLayer.Interfaces
{
    using Models.Models;
    using System.Threading.Tasks;

    public interface IVehicleBusinessLogic
    {
        Task<Response> CheckInVehicle(Vehicle vehicle);

        Task<Response> CheckOutVehicle(Vehicle vehicle);

        Task<Response> GetAllActiveVehicles(string vehicleType);
        
    }
}
