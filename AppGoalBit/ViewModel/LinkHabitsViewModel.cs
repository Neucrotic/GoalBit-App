using AppGoalBit.Data;
using AppGoalBit.Model;
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
        public ObservableCollection<Habit> UnlinkedHabits { get; } = new();
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
                // Do database CRUD
                Goal = await Database.GetGoalAsync(Goal.ID);

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
                _habit.HasLink = false;
            else
                _habit.HasLink = true;

            await Database.SaveHabitAsync(_habit);
            GetUpdateFromDatabase();
        }

        [RelayCommand]
        async Task DoneLinkAsync()
        {
            try
            {
                // Do CRUD Updates
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
