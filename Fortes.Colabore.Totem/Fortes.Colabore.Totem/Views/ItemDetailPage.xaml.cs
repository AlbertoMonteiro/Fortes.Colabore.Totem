using Fortes.Colabore.Totem.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Fortes.Colabore.Totem.Views
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