using AppGoalBit.Data;
using AppGoalBit.Model;
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
    public partial class NewGoalViewModel : ObservableObject
    {
        Goal G = new();

        GBDatabase Database;

        public NewGoalViewModel(GBDatabase _database)
        {
            Database = _database;
        }

        [RelayCommand]
        async Task NewGoalDoneAsync(Entry _e)
        {
            try
            {
                // Do Database CRUD
                G.Name = "Test";
                G.Description = "a simple test.";
                await Database.SaveGoalAsync(G);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("New Goal Error: Button", $"Complete goal button failed.", "OK");
            }
            finally
            {
                // Can pop page from stack because the Database has already stored the changes this page has made (still to do above).
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        async Task CancelGoalAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
