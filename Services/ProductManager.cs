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
    public class ProductManager
    {
        private readonly ApplicationDbContext _context;

        public ProductManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Product> GetAll()
        {
            return _context.Products
                .OrderByDescending(c=>c.Id).ToList();
        }
        public List<Product> GetFetauredAll()
        {
            return _context.Products
                .Where(c=>c.IsFeature)
                .OrderByDescending(c => c.Id).Take(15).ToList();
        }

        public List<Product> SaleProductAll()
        {
                return _context.Products
                   .Where(c => c.SaleProducts.All(d=>d.ProductID!=c.Id || d.Deadline<=DateTime.Now))
                   .OrderByDescending(c => c.Id)
                   .Take(15)
                   .ToList();
        }

        public Product? GetById(int? id)
        {
            return _context.Products.Find(id);
        }


        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void RemoveProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
