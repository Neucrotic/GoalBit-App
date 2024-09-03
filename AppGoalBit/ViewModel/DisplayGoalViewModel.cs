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
    public partial class DisplayGoalViewModel : ObservableObject
    {
        public ObservableCollection<Habit> Habits { get; } = new();
        GBDatabase Database;

        [ObservableProperty]
        Goal goal;

        [ObservableProperty]
        string title;

        public DisplayGoalViewModel(GBDatabase _database)
        {
            Database = _database;
            Title = "Goal Page";
        }

        [RelayCommand]
        async Task Appearing()
        {
            try
            {
                var habits = await Database.GetHabitListAsync();
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Habits.Clear();
                    foreach (var h in habits)
                    {
                        if (h.GoalKey == Goal.ID)
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
        async Task EditGoalAsync()
        {
            try
            {
                await Shell.Current.GoToAsync($"{nameof(NewGoalPage)}", true, new Dictionary<string, object>
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
        async Task GoToLinkHabitsAsync()
        {
            try
            {
                Goal g = new();
                g = Goal;
                await Shell.Current.GoToAsync($"{nameof(LinkHabitsPage)}", new Dictionary<string, object>
                                                                                {
                                                                                    {"Goal", g }
                                                                                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        [RelayCommand]
        async Task ResetGoalAsync()
        {
            try
            {
                bool answer = await Shell.Current.DisplayAlert("Do you want to Reset this Goal?", "Reset will revert this goal to 0 progress and set all linked habits to incomplete for today.", "Yes", "No");
                if (answer)
                {
                    // Reset the goal here.
                    Goal.ProgressPercentage = 0;

                    // Do database CRUD
                    await Database.SaveGoalAsync(Goal);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        async Task DeleteGoalAsync()
        {
            bool answer = false;
            try
            {
                answer = await Shell.Current.DisplayAlert("Delete Goal?", "Do you want to permanently delete this goal?", "Yes", "No");
                if(answer)
                {
                    // Do Database CRUD
                    await Database.DeleteGoalAsync(Goal);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                if (answer)
                    await Shell.Current.GoToAsync("..");
            }
        }
    }
}
