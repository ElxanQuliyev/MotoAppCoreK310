using Entities;

namespace Web.ViewModels
{
    public class IndexVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Category> Categories { get; set; }  
        public List<SaleProduct> Sales { get; set; }
        public  List<Product> Products { get; set; }
        public List<Product> FeaturedProducts { get; set; }

    }
}
