using DataAccess;
using Entities;


namespace Services
{
    public class CategoryManager
    {
        private readonly ApplicationDbContext _context;

        public CategoryManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category? GetById(int? id)
        {
            return _context.Categories.Find(id);
        }
        //Create
        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        //Edit
        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
        //delete
        public void RemoveCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
