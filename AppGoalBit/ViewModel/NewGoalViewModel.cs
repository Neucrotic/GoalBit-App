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
    [QueryProperty("Title", "string")]
    public partial class NewGoalViewModel : ObservableObject
    {
        [ObservableProperty]
        public string title;

        public NewGoalViewModel() { }

        [RelayCommand]
        async Task NewGoalDoneAsync()
        {
            try
            {
                //save this goal using datbase service.
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("New Goal Error: Button", $"Complete goal button failed.", "OK");
            }
        }
    }
}
