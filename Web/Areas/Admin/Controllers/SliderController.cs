using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly SliderManager _sliderManager;
        private readonly IWebHostEnvironment _env;

        public SliderController(SliderManager sliderManager, IWebHostEnvironment env)
        {
            _sliderManager = sliderManager;
            _env = env;
        }

        // GET: SliderController
        public ActionResult Index()
        {
            return View(_sliderManager.GetAll());
        }

        // GET: SliderController/Details/5
        public ActionResult Details(int id)
        {
            var slider = _sliderManager.GetById(id);
            return View(slider);
        }

        // GET: SliderController/Create
        public ActionResult Create()
        {
            return View();
        }   

        // POST: SliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormFile PhotoUrl,IFormFile BackgroundUrl, Slider slider )
        {
            if (BackgroundUrl != null)
            {
                string FileName = Guid.NewGuid() + BackgroundUrl.FileName;
                string rootPath = Path.Combine(_env.WebRootPath, "image");
                string PhotPath = Path.Combine(rootPath, FileName);
                using FileStream fl = new FileStream(PhotPath, FileMode.Create);
                BackgroundUrl.CopyTo(fl);
                slider.BackgroundUrl = "/image/" + FileName;
            }
            if (PhotoUrl != null)
            {
                string FileName  =Guid.NewGuid()+ PhotoUrl.FileName;
                string rootPath = Path.Combine(_env.WebRootPath, "image");
                string PhotPath = Path.Combine(rootPath, FileName);
                using FileStream fl  =new FileStream(PhotPath, FileMode.Create);
                PhotoUrl.CopyTo(fl);
                slider.PhotoUrl = "/image/" + FileName;
            }

            _sliderManager.AddProduct(slider);
            return RedirectToAction("Index");
        }

        // GET: SliderController/Edit/5
        public ActionResult Edit(int id)
        {
            var sldier  = _sliderManager.GetById(id);
            return View(sldier);
        }

        // POST: SliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slider slider, IFormFile NewPhoto, IFormFile NewBackground)
        {
            if (NewBackground != null)
            {
                string FileName = Guid.NewGuid() + NewBackground.FileName;
                string rootPAth = Path.Combine(_env.WebRootPath, "image");
                string PhotoPAth = Path.Combine(rootPAth, FileName);
                using FileStream fl = new FileStream(PhotoPAth, FileMode.Create);
                NewBackground.CopyTo(fl);
                slider.BackgroundUrl = "/image/" + FileName;
            }
            if (NewPhoto != null)
            {
                string FileName = Guid.NewGuid() + NewPhoto.FileName;
                string RootPath = Path.Combine(_env.WebRootPath, "image");
                string PhotoPath = Path.Combine(RootPath, FileName);
                using FileStream fl = new(PhotoPath, FileMode.Create);
                NewPhoto.CopyTo(fl);
                slider.PhotoUrl = "/image/" + FileName;
            }
            _sliderManager.UpdateProduct(slider);
            return RedirectToAction("Index");
        }

        // GET: SliderController/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)  return NotFound();
          var silder =  _sliderManager.GetById(id);
            if(silder == null) return NotFound();
            return View(silder) ;
        }

        // POST: SliderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var slider  = _sliderManager.GetById(id);   
            _sliderManager.RemoveProduct(slider);
            return RedirectToAction("Index");
        }
    }
}
