using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;


namespace Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class ProductController : Controller
    {
        private readonly ProductManager _productManager;
        private readonly CategoryManager _categoryManager;
        private readonly IWebHostEnvironment _env;

        public ProductController(ProductManager productManager, IWebHostEnvironment env, CategoryManager categoryManager)
        {
            _productManager = productManager;
            _env = env;
            _categoryManager = categoryManager;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View(_productManager.GetAll());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product  = _productManager.GetById(id);
            var category = _categoryManager.GetAll();
            ViewBag.Categories = category;

            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = _categoryManager.GetAll();
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormFile PhotoUrl,Product product)
        {
            if(PhotoUrl != null)
            {
                string FileName = Guid.NewGuid()+ PhotoUrl.FileName;
                string rootPath = Path.Combine(_env.WebRootPath, "image");
                string PhotoPAth = Path.Combine(rootPath, FileName);
                using FileStream fl =new FileStream(PhotoPAth, FileMode.Create);
                PhotoUrl.CopyTo(fl);
                product.PhotoUrl = "/image/" + FileName;
            }
            _productManager.AddProduct(product);
            return RedirectToAction("Index");   
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product  =_productManager.GetById(id);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormFile NewPhoto, Product product)
        {
            if(NewPhoto != null)
            {
                string FileName = Guid.NewGuid()+ NewPhoto.FileName;
                string RootPath = Path.Combine(_env.WebRootPath, "image");
                string PhotoPath  =Path.Combine(RootPath, FileName);
                using FileStream fl  = new FileStream(PhotoPath, FileMode.Create);
                NewPhoto.CopyTo(fl);
                product.PhotoUrl = "/image/" + FileName;
            }
            _productManager.UpdateProduct(product);
            return RedirectToAction("Index");


        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            var product = _productManager.GetById(id);

            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {

            var product =_productManager.GetById(id);
            _productManager.RemoveProduct(product);
            return RedirectToAction("Index");
        }
    }
}
