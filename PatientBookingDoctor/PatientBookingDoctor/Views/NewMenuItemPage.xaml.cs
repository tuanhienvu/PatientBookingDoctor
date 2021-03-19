using PatientBookingDoctor.Models;
using PatientBookingDoctor.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientBookingDoctor.Views
{
    public partial class NewMenuItemPage : ContentPage
    {
        public MenuItems Items { get; set; }

        public NewMenuItemPage()
        {
            InitializeComponent();
            BindingContext = new NewMenuItemViewModel();
        }
    }
}