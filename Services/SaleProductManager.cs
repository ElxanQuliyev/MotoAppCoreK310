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
    public class SaleProductManager
    {
        private readonly ApplicationDbContext _context;

        public SaleProductManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<SaleProduct> GetAll()
        {

            return _context.SaleProducts.Include(c=>c.Product).ToList();
        }

        public SaleProduct? GetById(int? id)
        {
            return _context.SaleProducts.Find(id);
        }


        public void AddProduct(SaleProduct saleProduct)
        {
            _context.SaleProducts.Add(saleProduct);
            _context.SaveChanges();
        }

        public void UpdateProduct(SaleProduct saleProduct)
        {
            _context.SaleProducts.Update(saleProduct);
            _context.SaveChanges();
        }

        public void RemoveProduct(SaleProduct saleProduct)
        {
            _context.SaleProducts.Remove(saleProduct);
            _context.SaveChanges();
        }
    }
}
