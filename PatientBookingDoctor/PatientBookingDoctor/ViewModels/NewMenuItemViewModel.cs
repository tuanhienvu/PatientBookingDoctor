using System;
using Xamarin.Forms;
using PatientBookingDoctor.Models;

namespace PatientBookingDoctor.ViewModels
{
    public class NewMenuItemViewModel : MenusViewModel
    {
        private string _titleText;
        private string _targetItemText;

        public NewMenuItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_titleText)
                   && !String.IsNullOrWhiteSpace(_targetItemText);
        }

        public string TitleText
        {
            get => _titleText;
            set => SetProperty(ref _titleText, value);
        }

        public string TargetItemText
        {
            get => _targetItemText;
            set => SetProperty(ref _targetItemText, value);
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
            MenuItems newItem = new MenuItems()
            {
                Id = Guid.NewGuid().ToString(),
                Title = TitleText,
                TargetItem = TargetItemText
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}