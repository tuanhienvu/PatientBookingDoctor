using PatientBookingDoctor.ViewModels;
using Xamarin.Forms;

namespace PatientBookingDoctor.Views
{
    public partial class MenuDetailPage : ContentPage
    {
        public MenuDetailPage()
        {
            InitializeComponent();
            BindingContext = new MenuDetailViewModel();
        }
    }
}