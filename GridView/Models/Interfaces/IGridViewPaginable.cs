using GridView.Models.Classes;

namespace GridView.Models.Interfaces
{
    public interface IGridViewPaginable<TGridViewItem> : IGridViewAction where TGridViewItem : IGridViewItem
    {
        public GridViewListBase<TGridViewItem> List { get; set; }
    }
}
