namespace BusinessLayer.BusinessLogic
{
    using BusinessLayer.Interfaces;
    using Models.Models;
    using ServiceAccessLayer.Interfaces;
    using ServiceAccessLayer.Services;
    using System;
    using System.Threading.Tasks;

    public class TCRMBusinessLogic : ITCRMBusinessLogic
    {
        #region Attributes
        private ITCRMServices tcrmServices;
        #endregion

        #region Contructors
        public TCRMBusinessLogic()
        {
            tcrmServices = new TCRMServices();
        }
        #endregion
        
        #region Interface Methods
        public async Task<Response> GetTCRM(DateTime date)
        {
            var response = await tcrmServices.GetCurrentTRM(date);
            return response;
        }
        #endregion
    }
}
