using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientBookingDoctor.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientBookingDoctor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : MasterDetailPage
    {
        public List<MainMenuItem> MainMenuItems { get; set; }
        public MenuPage()
        {
            BindingContext = this;

            // Build the Menu
            MainMenuItems = new List<MainMenuItem>()
            {
                new MainMenuItem() { Title = "Page One", Icon = "menu_inbox.png", TargetType = typeof(PageOne) },
                new MainMenuItem() { Title = "Page Two", Icon = "menu_stock.png", TargetType = typeof(PageTwo) }
            };

            // Set the default page, this is the "home" page.
            Detail = new NavigationPage(new PageOne());
            InitializeComponent();
        }

        public void MainMenuItem_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainMenuItem;
            if (item != null)
            {
                if (item.Title.Equals("Page One"))
                {
                    Detail = new NavigationPage(new PageOne());
                }
                else if (item.Title.Equals("Page Two"))
                {
                    Detail = new NavigationPage(new PageTwo());
                }

                MenuListView.SelectedItem = null;
                IsPresented = false;
            }
        }
}