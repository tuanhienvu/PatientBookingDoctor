using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using PatientBookingDoctor.Models;
using Xamarin.Forms;

namespace PatientBookingDoctor.ViewModels
{
    class MenuViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MenuItems> MenuItems { get; set; }
        public Command<MenuItems> ItemTapped { get; }
        public MenuViewModel()
        {

            MenuItems = new ObservableCollection<MenuItems>(new[]
            {
                new MenuItems { Id = 0, Title = "Page 1" },
                new MenuItems { Id = 1, Title = "Page 2" },
                new MenuItems { Id = 2, Title = "Page 3" },
                new MenuItems { Id = 3, Title = "Page 4" },
                new MenuItems { Id = 4, Title = "Page 5" },
            });

            ItemTapped = new Command<MenuItems>(OnItemSelected);
        }

        async void OnItemSelected(MenuItems item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(item.TargetType)}");
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
