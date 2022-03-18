using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CategoryManager _categoryManager;
        private readonly ProductManager _productManager;
        private readonly SaleProductManager _saleProductManager;
        private readonly SliderManager _sliderManager;
        public HomeController(ILogger<HomeController> logger, CategoryManager categoryManager, ProductManager productManager, SaleProductManager saleProductManager, SliderManager sliderManager)
        {
            _logger = logger;
            _categoryManager = categoryManager;
            _productManager = productManager;
            _saleProductManager = saleProductManager;
            _sliderManager = sliderManager;
        }

        public IActionResult Index()
        {
            IndexVM vm = new()
            {
                Categories = _categoryManager.GetAll(),
                Products=_productManager.GetAll(),
                Sales=_saleProductManager.GetAll(),
                Sliders=_sliderManager.GetAll(),
                FeaturedProducts=_productManager.GetFetauredAll()
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}