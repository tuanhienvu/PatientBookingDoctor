using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientBookingDoctor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientBookingDoctor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WaitingPatientPage : ContentPage
    {
        WaitingPatientViewModel _viewModel;
        public WaitingPatientPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new WaitingPatientViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}