using AppGoalBit.Data;
using AppGoalBit.Model;
using AppGoalBit.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace AppGoalBit.ViewModel
{
    [QueryProperty("Goal", "Goal")]
    public partial class LinkHabitsViewModel : ObservableObject
    {
        public ObservableCollection<Habit> Habits { get; } = new();
        GBDatabase Database;

        [ObservableProperty]
        Goal goal;

        [ObservableProperty]
        string title;

        public LinkHabitsViewModel(GBDatabase _database)
        {
            Database = _database;
            Title = "Link Habits";
        }

        [RelayCommand]
        async Task Appearing()
        {
            try
            {
                GetUpdateFromDatabase();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                await Shell.Current.DisplayAlert("Link Page Error", $"Failed to load initial page data.", "OK");
            }
        }

        [RelayCommand]
        async Task FlipHasLinkAsync(Habit _habit)
        {
            if (_habit.HasLink)
            {
                _habit.HasLink = false;
                _habit.GoalKey = 0;
            }
            else
            {
                _habit.HasLink = true;
                _habit.GoalKey = Goal.ID;
            }
                
            await Database.SaveHabitAsync(_habit);
            GetUpdateFromDatabase();
        }

        [RelayCommand]
        async Task DoneLinkAsync()
        {
            try
            {
                float habitCountTotal = 0;
                float linkedHabitsCount = 0;
                // Calculate the total percentage each habit would contribute towards the goal.
                // Set Goal Percentage here based on Habit data.

                // Get all the habits linked to these goal.
                List<Habit> habits = new();
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    foreach (var h in Habits)
                    {
                        if (h.GoalKey == Goal.ID)
                        {
                            habitCountTotal += h.CountReqToCompelte;
                            linkedHabitsCount++;
                        }
                    }
                    Goal.IncrementPercentageValue = linkedHabitsCount / habitCountTotal;
                });

                // Do CRUD Updates
                foreach (Habit h in Habits)
                {
                    await Database.SaveHabitAsync(h);
                }

                await Database.SaveGoalAsync(Goal);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                await Shell.Current.DisplayAlert("Link Page Error", $"Failed to save linking data.", "OK");
            }
            finally
            {
                // Pop this page to return.
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        async Task CancelLinkAsync()
        {
            try
            {
                // Pop this page without doing any saving.
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                await Shell.Current.DisplayAlert("Link Page Error", $"Failed to pop view from the stack.", "OK");
            }
        }

        [RelayCommand]
        async Task AddLinkedHabitAsync()
        {
            try
            {
                Habit habit = new Habit();
                habit.GoalKey = Goal.ID;
                habit.HasLink = true;

                // Go to a new habit page and pass in a linked habit.
                await Shell.Current.GoToAsync($"{nameof(NewHabitPage)}", true, new Dictionary<string, object>
                                                                            {
                                                                                { "Habit", habit },
                                                                                { "string",  "New Habit"},
                                                                                { "bool", false}
                                                                            });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                await Shell.Current.DisplayAlert("Link Page Error", $"Failed to pop view from the stack.", "OK");
            }
        }

        async void GetUpdateFromDatabase()
        {
            var habits = await Database.GetHabitListAsync();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Habits.Clear();
                foreach (var h in habits)
                {
                    Habits.Add(h);
                }
            });
        }
    }
}
