using AutoMapper;
using Formationn_Ecommerce.Application.Products.Dtos;
using Formationn_Ecommerce.Application.Products.Interfaces;
using Formationn_Ecommerce.Models;
using Formationn_Ecommerce.Models.Home;
using Formationn_Ecommerce.Models.Product;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Formationn_Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public HomeController(IProductServices productServices, IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {    
            if(!User.Identity.IsAuthenticated)
            {
                TempData["error"] = "Please Login First";
                return RedirectToAction("Login", "Auth");
            }
            IEnumerable<ProductDto> productDtos = await _productServices.ReadAllAsync();
            if (productDtos == null || !productDtos.Any())
            {
                TempData["error"] = "Product not found";
                return View(new List<HomeProductViewModel>()); // Return an empty view model list
            }

            var productViewModelDtoList = _mapper.Map<List<HomeProductViewModel>>(productDtos); // Map to a list            

            return View(productViewModelDtoList); // Pass the list to the view
        }

        public async Task<IActionResult> ProductDetails(Guid productId)
        {
            try
            {
                var product = await _productServices.ReadByIdAsync(productId); // Fetch product by ID
                if (product == null)
                {
                    TempData["error"] = "Product not found.";
                    return RedirectToAction(nameof(Index));
                }

                var productDto = _mapper.Map<HomeProductViewModel>(product); 
                return View(productDto); // Pass the product data to the view
            }
            catch (Exception ex)
            {
                TempData["error"] = $"An error occurred: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
