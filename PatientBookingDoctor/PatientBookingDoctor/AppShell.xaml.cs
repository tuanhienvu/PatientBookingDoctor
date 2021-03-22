using System;
using PatientBookingDoctor.Views;
using Xamarin.Forms;

namespace PatientBookingDoctor
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NoteEntryPage), typeof(NoteEntryPage));
            // Init();
        }
        // private void Init()
        // {
        //     main_nav.CurrentItem = nav_home;
        // }
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}