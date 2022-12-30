using BuyMore.Web.Models.Dtos;
using BuyMore.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BuyMore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> productList = new();
            var response = await _productService.GetAllProductsAsync<ResponseDto>();
            if (response!=null && response.IsSuccess)
            {
                productList = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(productList);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto productDtoModel)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.CreateProductAsync<ResponseDto>(productDtoModel);
                if (product != null && product.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
                
            }
            return View(productDtoModel);

        }


        public async Task<IActionResult> ProductEdit(int productId)
        {
            var response = await _productService.GetProductByIdAsync<ResponseDto>(productId);
            if (response != null && response.IsSuccess)
            {
                ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.UpdateProductAsync<ResponseDto>(model);
                if (product != null && product.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }

            }
            return View(model);

        }


        public async Task<IActionResult> ProductDelete(int productId)
        {
            var response = await _productService.GetProductByIdAsync<ResponseDto>(productId);
            if (response != null && response.IsSuccess)
            {
                ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.DeleteProductAsync<ResponseDto>(model.ProductId);
                if (product != null && product.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }

            }
            return View(model);

        }
    }
}
