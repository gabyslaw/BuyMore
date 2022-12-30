using BuyMore.Web.Models;
using BuyMore.Web.Models.Dtos;
using BuyMore.Web.Services.IServices;

namespace BuyMore.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.APIType.POST,
                Data = productDto,
                ApiUrl = SD.ProductAPIBase + "/api/product/",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.APIType.DELETE,
                ApiUrl = SD.ProductAPIBase + "/api/product/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.APIType.GET,
                ApiUrl = SD.ProductAPIBase + "/api/product/",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.APIType.GET,
                ApiUrl = SD.ProductAPIBase + "/api/product/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.APIType.PUT,
                Data = productDto,
                ApiUrl = SD.ProductAPIBase + "/api/product/",
                AccessToken = ""
            });
        }
    }
}
