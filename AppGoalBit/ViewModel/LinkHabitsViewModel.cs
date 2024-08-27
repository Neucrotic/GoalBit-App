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
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
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
        }
    }
}
