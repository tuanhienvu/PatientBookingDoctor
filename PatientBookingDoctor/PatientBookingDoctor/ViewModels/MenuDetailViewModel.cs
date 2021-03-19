using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace PatientBookingDoctor.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class MenuDetailViewModel : MenusViewModel
    {
        private string itemId;
        private string title;
        private string targetItem;
        public string Id { get; set; }

        public string TitleText
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string TargetText
        {
            get => targetItem;
            set => SetProperty(ref targetItem, value);
        }

        public string ItemId
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

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                TitleText = item.Title;
                TargetText = item.TargetItem;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Items");
            }
        }
    }
}