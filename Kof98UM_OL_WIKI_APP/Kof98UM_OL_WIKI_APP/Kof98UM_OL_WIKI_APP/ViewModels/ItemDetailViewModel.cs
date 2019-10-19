using System;

using Kof98UM_OL_WIKI_APP.Models;

namespace Kof98UM_OL_WIKI_APP.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
