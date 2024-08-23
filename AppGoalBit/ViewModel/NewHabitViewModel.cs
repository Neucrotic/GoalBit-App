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
    [QueryProperty("Habit", "Habit")]
    [QueryProperty("Title", "string")]
    [QueryProperty("Visible", "bool")]
    public partial class NewHabitViewModel : ObservableObject
    {
        [ObservableProperty]
        Habit habit;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        bool visible;

        public NewHabitViewModel() { }

        [RelayCommand]
        async Task ConfirmHabitAsync()
        {
            try
            {
                // Pop the Stack: await Shell.Current.Pop;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Habits Error: New Habit", $"Error editing or creating a habit.", "OK");
            }
        }

        [RelayCommand]
        async Task SetHabitNullAsync()
        {
            try
            {
                Habit.Name = "null";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Habits Error: Delete Habit", $"Error deleting a habit.", "OK");

            }
            finally
            {
                await Shell.Current.GoToAsync($"{nameof(HabitsPage)}", true);
            }
        }
    }
}
