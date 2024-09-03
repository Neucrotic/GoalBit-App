using AppGoalBit.Data;
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
    public partial class SettingsViewModel : ObservableObject
    {
        GBDatabase Database;

        public SettingsViewModel(GBDatabase _database)
        {
            Database = _database;
        }

        [RelayCommand]
        async Task ResetDatabaseAsync()
        {
            bool answer = false;

            try
            {
                // Check user input with a pop-up
                answer = await Shell.Current.DisplayAlert("Reset Data?", "This will delete all habit and goal data, reseting the app to it's default state.", "Delete It", "Keep My Data");
                
                if (answer)
                    answer = await Shell.Current.DisplayAlert("Delete All Data", "Are you sure you want to lose everything?", "Yes", "No");

                if(answer)
                    answer = await Shell.Current.DisplayAlert("Deleting Data", "Confirming data deletion.", "Confirm", "Cancel");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Progress Error: Button", $"Failed to reset database", "OK");
            }
            finally
            {
                // Reset Database
                if (answer)
                    await Database.WipeDatabaseClean();
            }
        }
    }
}
