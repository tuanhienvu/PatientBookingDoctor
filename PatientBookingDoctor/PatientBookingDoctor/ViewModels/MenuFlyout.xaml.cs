using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientBookingDoctor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuFlyout : ContentPage
    {
        public ListView ListView;
        
        public MenuFlyout()
        {
            InitializeComponent();

            BindingContext = new MenuFlyoutViewModel();
            ListView = MenuItemsListView;
        }
        
        class MenuFlyoutViewModel : INotifyPropertyChanged
        {
            
            
            public ObservableCollection<MenuItem> MenuItems { get; set; }
            public Command<MenuItem> ItemTapped { get; }
            public MenuFlyoutViewModel()
            {
                ItemTapped = new Command<MenuItem>(OnItemSelected);


                MenuItems = new ObservableCollection<MenuItem>(new[]
                {
                    new MenuItem { Id = 0, Title = "BN chờ khám" },
                    new MenuItem { Id = 1, Title = "Lịch Khám bệnh" },
                    new MenuItem { Id = 2, Title = "Nhật ký nhận bệnh" },
                    new MenuItem { Id = 3, Title = "Danh sách khám bệnh mới" },
                    new MenuItem { Id = 4, Title = "Bản tin" },
                    new MenuItem { Id = 5, Title = "Thông tin cá nhân" },
                    new MenuItem { Id = 6, Title = "Hướng dẫn sử dụng" },
                    new MenuItem { Id = 7, Title = "Đăng xuất", TargetItem = "//LoginPage" }
                });
            }

            async void OnItemSelected(MenuItem item)
            {
                if (item == null)
                    return;

                // This will push the ItemDetailPage onto the navigation stack
                await Shell.Current.GoToAsync($"{nameof(MenuDetail)}?{nameof(MenuItem.Id)}={item.TargetItem}");
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

}