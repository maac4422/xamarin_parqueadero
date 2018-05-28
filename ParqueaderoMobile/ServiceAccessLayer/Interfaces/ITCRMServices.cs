namespace ServiceAccessLayer.Interfaces
{
    using Models.Models;
    using System;
    using System.Threading.Tasks;

    public interface ITCRMServices
    {
        Task<Response> GetCurrentTRM(DateTime date);
    }
}
