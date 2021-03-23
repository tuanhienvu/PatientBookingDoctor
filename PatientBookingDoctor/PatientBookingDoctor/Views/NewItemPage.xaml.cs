using PatientBookingDoctor.Models;
using PatientBookingDoctor.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientBookingDoctor.Views
{
    public partial class NewItemPage : ContentPage
    {
        public WaitingPatient Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}