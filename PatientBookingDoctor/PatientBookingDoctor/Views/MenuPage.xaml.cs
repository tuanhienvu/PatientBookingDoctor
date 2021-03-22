using PatientBookingDoctor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientBookingDoctor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPageFlyout : ContentPage
    {
        public ListView ListView;

        public MenuPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MenuViewModel();
            ListView = MenuItemsListView;
        }
    }
}