namespace ParqueaderoMobile.ViewModels
{
    using BusinessLayer.BusinessLogic;
    using BusinessLayer.Interfaces;
    using Models.Models;
    using System;
    using Xamarin.Forms;

    public class TCRMViewModel : BaseViewModel
    {
        #region Attributes
        private TCRM tcrmObject;
        private ITCRMBusinessLogic tcrmBusinessLogic;
        #endregion

        #region Properties
        public TCRM TCRMObject
        {
            get
            {
                return this.tcrmObject;
            }
            set
            {
                SetValue(ref this.tcrmObject, value);
            }
        }

        #endregion

        #region Constructors
        public TCRMViewModel()
        {
            tcrmBusinessLogic = new TCRMBusinessLogic();
            GetTCRM();
        }
        #endregion

        #region Methods
        private async void GetTCRM()
        {
            Response response = await tcrmBusinessLogic.GetTCRM(DateTime.Now);
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Error obteniendo el TCRM",
                    "Aceptar");
                return;
            }
            this.TCRMObject = (TCRM)response.Result;
        }
        #endregion
    }
}
