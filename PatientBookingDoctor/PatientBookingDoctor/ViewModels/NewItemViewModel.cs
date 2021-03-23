using PatientBookingDoctor.Models;
using PatientBookingDoctor.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PatientBookingDoctor.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private Guid itemId;

        private string registrationDate;

        private string patientName;

        private string examinationDept;

        private string clinicName;

        public int Id { get; set; }


        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(PatientName)
                   && !String.IsNullOrWhiteSpace(examinationDept)
                   && !String.IsNullOrWhiteSpace(clinicName);
        }

        public Guid ItemId
        {
            get => itemId;
            set => SetProperty(ref itemId, value);
        }

        public string RegistrationDate
        {
            get => registrationDate;
            set => SetProperty(ref registrationDate, value);
        }

        public string PatientName
        {
            get => patientName;
            set => SetProperty(ref patientName, value);
        }

        public string ExaminationDept
        {
            get => examinationDept;
            set => SetProperty(ref examinationDept, value);
        }

        public string ClinicName
        {
            get => clinicName;
            set => SetProperty(ref clinicName, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            WaitingPatient newItem = new WaitingPatient()
            {
                ID = ItemId,
                RegistrationDate = RegistrationDate,
                PatientName = PatientName,
                ExaminationDept = ExaminationDept,
                ClinicName = ClinicName
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}