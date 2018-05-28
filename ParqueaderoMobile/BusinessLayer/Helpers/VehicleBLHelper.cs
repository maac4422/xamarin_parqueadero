namespace BusinessLayer.Helpers
{
    using Models.Enumerators;
    using Models.Models;

    public static class VehicleBLHelper
    {
        public static bool IsMotorcycle(Vehicle vehicle)
        {
            return vehicle.VehicleType.Equals(VehicleEnumerator.VehicleTypes.motorcycle.ToString());
        }
        public static bool IsMotorcycle(string vehicleType)
        {
            return vehicleType.Equals(VehicleEnumerator.VehicleTypes.motorcycle.ToString());
        }

        public static bool IsCar(Vehicle vehicle)
        {
            return vehicle.VehicleType.Equals(VehicleEnumerator.VehicleTypes.car.ToString());
        }
        
        public static bool IsCar(string vehicleType)
        {
            return vehicleType.Equals(VehicleEnumerator.VehicleTypes.car.ToString());
        }
    }
}
