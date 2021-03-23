using PatientBookingDoctor.Models;
using PatientBookingDoctor.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PatientBookingDoctor.ViewModels
{
    public class WaitingPatientViewModel : BaseViewModel
    {

        private WaitingPatient _selectedItem;

        public ObservableCollection<WaitingPatient> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<WaitingPatient> ItemTapped { get; }

        public WaitingPatientViewModel()
        {
            Title = "Bệnh nhân chờ khám";
            Items = new ObservableCollection<WaitingPatient>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<WaitingPatient>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                // List<WaitingPatient> items = new List<WaitingPatient>()
                // {
                //     new WaitingPatient { ID = Guid.NewGuid(), RegistrationDate = "22/12/2020", PatientName = "Vũ Tuấn Hiền",ExaminationDept = "Khoa Nội", ClinicName = "PKĐK Thống Nhất"},
                //     new WaitingPatient { ID = Guid.NewGuid(), RegistrationDate = "22/12/2020", PatientName = "Đoàn Minh Hoàng",ExaminationDept = "Khoa Nội", ClinicName = "PKĐK Thống Nhất"},
                //     new WaitingPatient { ID = Guid.NewGuid(), RegistrationDate = "22/12/2020", PatientName = "Nguyễn Công Ấn", ExaminationDept = "Khoa Nội", ClinicName = "PKĐK Thống Nhất" },
                //     new WaitingPatient { ID = Guid.NewGuid(), RegistrationDate = "22/12/2020", PatientName = "Nguyễn Tấn Nhân", ExaminationDept = "Khoa Nội", ClinicName = "PKĐK Thống Nhất" },
                //     new WaitingPatient { ID = Guid.NewGuid(), RegistrationDate = "22/12/2020", PatientName = "Lê Nhật Nam", ExaminationDept = "Khoa Nội", ClinicName = "PKĐK Thống Nhất" },
                // };
                var items =  await DataStore.GetItemsAsync(true);
                
                foreach (var it in items)
                {
                    Items.Add(it);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public WaitingPatient SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(WaitingPatient item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            // await Shell.Current.GoToAsync($"{nameof(WaitingPatientDetailPage)}?{nameof(WaitingPatientDetailViewModel.ItemId)}={item.ID}");
            await Shell.Current.GoToAsync(nameof(WaitingPatientDetailPage));
        }
    }
}