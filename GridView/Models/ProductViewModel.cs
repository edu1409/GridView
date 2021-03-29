using GridView.Models.Interfaces;

namespace GridView.Models
{
    public class ProductViewModel : IGridViewItem
    {
        public string Product { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
    }
}
