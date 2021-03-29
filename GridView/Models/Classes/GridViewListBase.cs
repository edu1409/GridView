using GridView.Models.Interfaces;
using System.Collections.Generic;

namespace GridView.Models.Classes
{
    public abstract class GridViewListBase<TGridViewItem> : List<TGridViewItem> where TGridViewItem : IGridViewItem {  }
}
