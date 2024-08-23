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
        async Task OpenAccountPageModalAsync()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Progress Error: Button", $"Add habit button failed.", "OK");
            }
        }
    }
}
