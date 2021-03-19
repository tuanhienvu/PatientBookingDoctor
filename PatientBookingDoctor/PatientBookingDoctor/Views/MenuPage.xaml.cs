﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientBookingDoctor.Models;
using PatientBookingDoctor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientBookingDoctor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MenusViewModel _viewModel;
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MenusViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}