using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoalBitApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalBitApp.ViewModel
{
    [QueryProperty("Habit", "Habit")]
    public partial class NewHabitViewModel : ObservableObject
    {
        [ObservableProperty]
        Habit habit;

        public NewHabitViewModel() { }

        [RelayCommand]
        async Task ConfirmHabitAsync(Habit _habit)
        {
            try
            {
                if (_habit.Name == "___")
                {
                    //do not update habit data, just pop page
                }
                else
                {
                    //send habit to HabitsPage
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Habits Error: New Habit", $"Error editing or creating a habit.", "OK");
            }
        }
    }
}
