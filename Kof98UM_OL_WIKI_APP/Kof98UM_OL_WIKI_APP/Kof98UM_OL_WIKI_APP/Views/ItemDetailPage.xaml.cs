using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Kof98UM_OL_WIKI_APP.Models;
using Kof98UM_OL_WIKI_APP.ViewModels;

namespace Kof98UM_OL_WIKI_APP.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}