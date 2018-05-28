namespace ParqueaderoMobile.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public CarsViewModel Cars { get; set; }
        public VehicleViewModel Vehicle { get; set; }
        public VehicleCheckInViewModel VehicleCheckIn { get; set; }
        public MotorcylesViewModel Motorcycles { get; set; }
        public TCRMViewModel TCRM { get; set; }

        #endregion


        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.TCRM = new TCRMViewModel();
            this.Cars = new CarsViewModel();
            this.Motorcycles = new MotorcylesViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            else
            {
                return instance;
            }
        }
        #endregion
    }
}
