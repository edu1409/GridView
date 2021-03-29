using GridView.Models.Classes;
using GridView.Models.Interfaces;

namespace GridView.Models
{
    public class PaginableGridViewModel : IGridViewPaginable<IGridViewItem>
    {
        public string Action { get; set; }
        public GridViewListBase<IGridViewItem> List { get; set; }
    }
}
