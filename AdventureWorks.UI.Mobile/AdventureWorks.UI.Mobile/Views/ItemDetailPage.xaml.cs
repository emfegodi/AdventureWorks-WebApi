using AdventureWorks.UI.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AdventureWorks.UI.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}