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
    public partial class WaitingPatientDetailPage : ContentPage
    {
        public WaitingPatientDetailPage()
        {
            InitializeComponent();
            BindingContext = new WaitingPatientDetailViewModel();
        }
    }
}