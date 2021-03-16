using PatientBookingDoctor.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PatientBookingDoctor.Views
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