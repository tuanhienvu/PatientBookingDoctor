using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using PatientBookingDoctor.Models;
using PatientBookingDoctor.Services;
using PatientBookingDoctor.Views;
using Xamarin.Forms;

namespace PatientBookingDoctor.ViewModels
{
    public class MenusViewModel : BaseViewModel
    {
        public IDataStore<MenuItems> DataStore => DependencyService.Get<IDataStore<MenuItems>>();

        private MenuItems _selectedItem;

        public ObservableCollection<MenuItems> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<MenuItems> ItemTapped { get; }

        public MenusViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<MenuItems>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<MenuItems>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(false);
                foreach (var item in items)
                {
                    Items.Add(item);
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

        public MenuItems SelectedItem
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
            await Shell.Current.GoToAsync(nameof(NewMenuItemPage));
        }

        async void OnItemSelected(MenuItems item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(MenuDetailPage)}?{nameof(MenuDetailViewModel.ItemId)}={item.Id}");
        }
    }
}