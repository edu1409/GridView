using GridView.Models.Classes;

namespace GridView.Models.Interfaces
{
    public interface IGridView<TGridViewItem> : IGridViewSearchable<TGridViewItem>, IGridViewPaginable<TGridViewItem> where TGridViewItem: IGridViewItem 
    {
        public new GridViewListBase<IGridViewItem> List { get; set; }
    }
}
