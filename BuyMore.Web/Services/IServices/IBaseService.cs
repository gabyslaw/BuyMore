using BuyMore.Web.Models;
using BuyMore.Web.Models.Dtos;

namespace BuyMore.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
