using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoalBitApp.Model;
using GoalBitApp.Views;

namespace GoalBitApp
{
    public partial class HabitsViewModel : ObservableObject
    {
        public ObservableCollection<Habit> Habits { get; } = new();
        List<Habit> ConfirmedHabits = new();

        public HabitsViewModel()
        {
            Habit habit1 = new Habit(1, "Read", "Read at least 1 chapter of any book.");
            Habit habit2 = new Habit(2, "Write", "Write until the word count goal has been reached.");
            Habit habit3 = new Habit(3, "Code", "Work on a feature of the current app you are developing.");

            Habits.Add(habit1);
            Habits.Add(habit2);
            Habits.Add(habit3);
        }

        [RelayCommand]
        async Task AddHabitAsync(Habit _habit)
        {
            try
            {
                if (_habit is null)
                {
                    _habit = new Habit(Habits.Count, "Name", "Describe your habit here.");
                }
                else
                {
                    return;
                }

                await Shell.Current.GoToAsync($"{nameof(NewHabitPage)}", true, new Dictionary<string, object>
                                                                                {
                                                                                    { "Habit", _habit },
                                                                                    { "string",  "New Habit"},
                                                                                    { "bool", false}
                                                                                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Habits Error: Swipe", $"Add habit button failed.", "OK");
            }
        }

        [RelayCommand]
        async Task EditHabitAsync(Habit _habit)
        {
            if (_habit is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(NewHabitPage)}", true, new Dictionary<string, object>
                                                                                {
                                                                                    { "Habit", _habit },
                                                                                    { "string",  "Edit Habit"},
                                                                                    { "bool", true}
                                                                                });
        }

        [RelayCommand]
        async Task DeleteHabitAsync(Habit _habit)
        {
            try
            {
                Habits.Remove(_habit);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                await Shell.Current.DisplayAlert("Habits Error: Swipe", $"Delete Habit Failed", "OK");
            }
        }

        [RelayCommand]
        async Task ConfrimHabitAsync(Habit _habit)
        {
            try
            {
                await Shell.Current.DisplayPromptAsync("Confirm?", "Have you maintained this habit today?", "Yes", "No");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                await Shell.Current.DisplayAlert("Habits Error: Tap", $"Error Confirming Habit", "OK");
            }
            finally
            {
                ConfirmedHabits.Add(_habit);
                Habits.Remove( _habit);
            }
        }

        void AddHabit(Habit _habit)
        {
            Habits.Add(_habit);
        }
    }
}
