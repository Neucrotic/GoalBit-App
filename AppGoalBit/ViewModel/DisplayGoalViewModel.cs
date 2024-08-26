using AppGoalBit.Data;
using AppGoalBit.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace AppGoalBit.ViewModel
{
    [QueryProperty("Goal", "Goal")]
    public partial class DisplayGoalViewModel : ObservableObject
    {
        public ObservableCollection<Habit> Habits { get; } = new();
        GBDatabase Database;

        [ObservableProperty]
        Goal goal;

        [ObservableProperty]
        bool viewOnly;

        [ObservableProperty]
        string title;

        public DisplayGoalViewModel(GBDatabase _database)
        {
            Title = "Goal Page";
            Database = _database;
        }

        [RelayCommand]
        async Task Appearing()
        {
            try
            {
                // Do database CRUD
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
    }
}
