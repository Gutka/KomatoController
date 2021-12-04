using KomatoController.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace KomatoController.Views
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