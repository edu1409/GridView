using GridView.Models.Classes;
using GridView.Models.Interfaces;

namespace GridView.Models
{
    public class SearchableGridViewModel : IGridViewSearchable<IGridViewItem>
    {
        public string Action { get; set; }
        public string SortField { get; set; }
        public bool SortAscending { get; set; }
        public string CurrentFilter { get; set; }
        public GridViewListBase<IGridViewItem> List { get; set; }
    }
}
