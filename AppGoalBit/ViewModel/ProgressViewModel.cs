using AppGoalBit.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGoalBit.ViewModel
{
    public partial class ProgressViewModel : ObservableObject
    {
        public ProgressViewModel()
        {

        }

        [RelayCommand]
        async Task OpenSettingsAsync()
        {
            try
            {
                await Shell.Current.GoToAsync($"{nameof(SettingsPage)}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Progress Error: Button", $"Failed to go to settings.", "OK");
            }
        }
    }
}
