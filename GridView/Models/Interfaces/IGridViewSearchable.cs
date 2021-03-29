using GridView.Models.Classes;

namespace GridView.Models.Interfaces
{
    public interface IGridViewSearchable<TGridViewItem> : IGridViewAction where TGridViewItem : IGridViewItem
    {
        public string SortField { get; set; }
        public bool SortAscending { get; set; }
        public string CurrentFilter { get; set; }
        public GridViewListBase<TGridViewItem> List { get; set; }
    }
}
