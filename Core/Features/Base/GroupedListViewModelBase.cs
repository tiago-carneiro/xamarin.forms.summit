using System;
using System.Collections.Generic;
using System.Linq;

namespace Xamarin.Summit
{
    public abstract class GroupedListViewModelBase<TGroup, TModel> 
        : ListViewModelBase<IGrouping<TGroup, TModel>, TModel> where TModel : class
    {
        protected GroupedListViewModelBase(string title, bool implementLoadInfoHandle = false) 
            : base(title, implementLoadInfoHandle)
        {
        }

        protected abstract Func<TModel, TGroup> GroupBy();

        protected override void AddItems(IEnumerable<TModel> items)
            => items?.GroupBy(GroupBy()).ToList()?.ForEach(item => Items.Add(item));
    }
}
