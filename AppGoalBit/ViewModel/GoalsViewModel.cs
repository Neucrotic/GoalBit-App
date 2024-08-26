using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppGoalBit.Data;
using AppGoalBit.Model;
using AppGoalBit.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppGoalBit.ViewModel
{
    public partial class GoalsViewModel : ObservableObject
    {
        public ObservableCollection<Goal> Goals { get; } = new();

        GBDatabase Database;

        public GoalsViewModel(GBDatabase _database)
        {
            Database = _database;
        }

        [RelayCommand]
        async Task Appearing()
        {
            // Load from Database here
            try
            {
                // Do database CRUD
                var goals = await Database.GetGoalListAsync();
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Goals.Clear();
                    foreach (var g in goals)
                    {
                        Goals.Add(g);
                    }
                });   
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                await Shell.Current.DisplayAlert("Database Error", $"Error with OnAppear Goals ViewModel", "OK");
            }
        }

        [RelayCommand]
        async Task Disappearing()
        {
            // Save to Database here
            try
            {
                // Do database CRUD
                foreach (var g in Goals)
                {
                    await Database.SaveGoalAsync(g);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                await Shell.Current.DisplayAlert("Database Error", $"Error with OnDisappear Goals ViewModel", "OK");
            }
        }

        [RelayCommand]
        async Task AddGoalAsync()
        {
            try
            {
                await Shell.Current.GoToAsync($"{nameof(NewGoalPage)}", true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Goals Error: Button", $"Add goal button failed.", "OK");
            }
        }

        [RelayCommand]
        async Task GoalTappedAsync(Goal _goal)
        {
            try
            {
                // Add goal data to be sent to display page
                await Shell.Current.GoToAsync($"{nameof(DisplayGoalPage)}", true, new Dictionary<string, object>
                                                                                {
                                                                                    {"Goal", _goal }
                                                                                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Goals Error: Button", $"Tap Goal Gesture Failed.", "OK");
            }
        }
    }
}
