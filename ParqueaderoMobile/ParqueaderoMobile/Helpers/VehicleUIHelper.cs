namespace ParqueaderoMobile.Helpers
{
    using Models.Enumerators;
    using Models.Models;
    using ParqueaderoMobile.ViewModels;
    using System.Collections.Generic;
    using System.Linq;

    public static class VehicleHelper
    {

        public static IEnumerable<VehicleItemViewModel> ToVehicleItemViewModel(List<Vehicle> vehiclesList)
        {
            return vehiclesList.Select(l => new VehicleItemViewModel
            {
                Id = l.Id,
                LicencePlate = l.LicencePlate,
                EntryTime = l.EntryTime,
                Displacement = l.Displacement,
                DepartureTime = l.DepartureTime,
                Payment = l.Payment,
                State = l.State,
                VehicleType = l.VehicleType
            });
        }
    }
}
