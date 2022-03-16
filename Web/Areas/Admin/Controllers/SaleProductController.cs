using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Web.Areas.Admin.Controllers
{
    [Area (nameof(Admin))]
    public class SaleProductController : Controller
    {
        private readonly ProductManager _productManager;
        private readonly SaleProductManager _saleProductManager;
        private readonly IWebHostEnvironment _env;

        public SaleProductController(SaleProductManager saleProductManager, IWebHostEnvironment env, ProductManager productManager)
        {
            _saleProductManager = saleProductManager;
            _env = env;
            _productManager = productManager;
        }

        // GET: SaleProductController
        public ActionResult Index()
        {
            return View(_saleProductManager.GetAll());
        }

        // GET: SaleProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleProductController/Create
        public ActionResult Create()
        {
            ViewBag.Products = _productManager.SaleProductAll();

            return View();
        }

        // POST: SaleProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( SaleProduct saleProduct)
        {
            if (ModelState.IsValid)
            {
                if (saleProduct.Deadline >= DateTime.Now)
                {
                    _saleProductManager.AddProduct(saleProduct);
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Products = _productManager.SaleProductAll();
            return View(saleProduct);
        }

        // GET: SaleProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var SaleProduct  = _saleProductManager.GetById(id);
            return View(SaleProduct);
        }

        // POST: SaleProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,SaleProduct saleProduct)
        {
            _saleProductManager.UpdateProduct(saleProduct);
            return RedirectToAction("Index");


        }

        // GET: SaleProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
