namespace BusinessLayer.Interfaces
{
    using Models.Models;
    using System;
    using System.Threading.Tasks;

    public interface ITCRMBusinessLogic
    {
        Task<Response> GetTCRM(DateTime date);
    }
}
