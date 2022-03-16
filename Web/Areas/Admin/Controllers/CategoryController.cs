using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class CategoryController : Controller
    {
        private readonly CategoryManager _categoryManager;
        private readonly IWebHostEnvironment _env;

        public CategoryController(CategoryManager categoryManager, IWebHostEnvironment env)
        {
            _categoryManager = categoryManager;
            _env = env;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            return View(_categoryManager.GetAll());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category =_categoryManager.GetById(id);
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category,IFormFile PhotoUrl)
        {
            if (PhotoUrl != null)
            {
                string FileName  = Guid.NewGuid() + PhotoUrl.FileName;
                string rootPath  = Path.Combine(_env.WebRootPath,"image");
                string PhotoPath  = Path.Combine(rootPath,FileName);   
                using FileStream fl  = new (PhotoPath, FileMode.Create);
                PhotoUrl.CopyTo(fl);
                category.PhotoUrl = "/image/" + FileName;


            }
            
                _categoryManager.AddCategory(category);
                return RedirectToAction(nameof(Index));
            
           
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var Category  = _categoryManager.GetById(id);
            return View(Category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormFile NewPhoto,Category categgory)
        {
            if(NewPhoto != null)
            {
                string FileName  = Guid.NewGuid() + NewPhoto.FileName;
                string RootPath = Path.Combine(_env.WebRootPath,"image");
                string PhotoPath  =Path.Combine(RootPath,FileName);
                using FileStream fl  =new(PhotoPath, FileMode.Create);
                NewPhoto.CopyTo(fl);
                categgory.PhotoUrl = "/image/" + FileName;
            }

            _categoryManager.UpdateCategory(categgory);
            return RedirectToAction(nameof(Index)); 
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var category =_categoryManager.GetById(id);
            if(category==null) return NotFound();   
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            var Category = _categoryManager.GetById(id);
            _categoryManager.RemoveCategory(Category);
            return RedirectToAction("Index");

        }
    }
}
