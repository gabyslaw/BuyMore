using static BuyMore.Web.SD;

namespace BuyMore.Web.Models
{
    public class ApiRequest
    {
        public APIType ApiType { get; set; } = APIType.GET;
        public string ApiUrl { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
