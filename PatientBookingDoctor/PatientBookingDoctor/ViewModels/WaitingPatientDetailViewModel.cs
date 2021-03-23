using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace PatientBookingDoctor.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    class WaitingPatientDetailViewModel: BaseViewModel
    {
        private Guid itemId;

        private string registrationDate;

        private string patientName;

        private string examinationDept;
        
        private string clinicName;

        public Guid Id { get; set; }
        
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
        public Guid ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }
        public async void LoadItemId(Guid itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = Guid.NewGuid();
                RegistrationDate = item.RegistrationDate;
                PatientName = item.PatientName;
                ExaminationDept = item.ExaminationDept;
                ClinicName = item.ClinicName;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}