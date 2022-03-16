using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SliderManager
    {
        private readonly ApplicationDbContext _context;

        public SliderManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Slider> GetAll()
        {

            return _context.Sliders.ToList();
        }

        public Slider? GetById(int? id)
        {
            return _context.Sliders.Find(id);
        }


        public void AddProduct(Slider slider)
        {
            _context.Sliders.Add(slider);
            _context.SaveChanges();
        }

        public void UpdateProduct(Slider slider)
        {
            _context.Sliders.Update(slider);
            _context.SaveChanges();
        }

        public void RemoveProduct(Slider slider)
        {
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
        }
    }

}
