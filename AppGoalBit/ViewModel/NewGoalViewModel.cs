using AppGoalBit.Data;
using AppGoalBit.Model;
using AppGoalBit.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGoalBit.ViewModel
{
    [QueryProperty("Goal", "Goal")]
    public partial class NewGoalViewModel : ObservableObject
    {
        public ObservableCollection<Habit> Habits { get; } = new();
        GBDatabase Database;

        [ObservableProperty]
        public Goal goal;

        public NewGoalViewModel(GBDatabase _database)
        {
            Database = _database;
        }

        [RelayCommand]
        async Task ValidateGoalNameAsync()
        {
            // I can use this to check character length, string format etc later on.
            // Make sure field is not blank etc or has at least ran once.
        }

        [RelayCommand]
        async Task ValidateGoalDescriptionAsync()
        {
            // Same as above validator function
        }

        [RelayCommand]
        async Task GoToLinkHabitsAsync()
        {
            try
            {
                await Shell.Current.GoToAsync($"{nameof(LinkHabitsPage)}", new Dictionary<string, object>
                                                                                {
                                                                                    {"Goal", Goal }
                                                                                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        [RelayCommand]
        async Task NewGoalDoneAsync()
        {
            try
            {
                // Validate user input FIRST
                // Do Database CRUD
                await Database.SaveGoalAsync(Goal);
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
