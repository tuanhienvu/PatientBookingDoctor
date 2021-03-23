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
            // Routing.RegisterRoute(nameof(NoteEntryPage), typeof(NoteEntryPage));
            Routing.RegisterRoute(nameof(WaitingPatientDetailPage), typeof(WaitingPatientDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
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