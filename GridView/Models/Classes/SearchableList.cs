using GridView.Models.Interfaces;

namespace GridView.Models.Classes
{
    public class SearchableList<TGridViewItem> : GridViewListBase<TGridViewItem> where TGridViewItem : IGridViewItem { }
}
