﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientBookingDoctor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientBookingDoctor.Views
{
    public partial class HomePage : CarouselPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        async void OnWPTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WaitingPatientPage());
            // await Shell.Current.GoToAsync("WaitingPatientPage");
        }
    }
}