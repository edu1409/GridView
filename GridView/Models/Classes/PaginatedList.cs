using GridView.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GridView.Models.Classes
{
    public class PaginatedList<TGridViewItem> : GridViewListBase<TGridViewItem> where TGridViewItem : IGridViewItem
    {
        public int CurrentPage { get; private set; }
        public int PageCount { get; private set; }

        public PaginatedList(IEnumerable<TGridViewItem> source, int pageNumber, int pageSize)
        {
            int count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            CurrentPage = pageNumber;
            PageCount = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < PageCount);
            }
        }
    }
}