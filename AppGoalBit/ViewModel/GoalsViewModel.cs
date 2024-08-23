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
            Goal goal1 = new();
            goal1.Name = "Financial Freedom Through Coding Apps";
            goal1.Description = "I want to use my coding skills to build apps which I can market and monotize in order to quit my day job and mak art full time.";
            Goal goal2 = new();
            goal2.Name = "Write a Book";
            goal2.Description = "By incrementally working through each section of a story, I want to finnaly write a work of fiction in the novel format. Even if it is never published is it an important first step.";

            Goals.Add(goal1);
            Goals.Add(goal2);
        }

        [RelayCommand]
        async Task Appearing()
        {
            try
            {
                var goals = await Database.GetGoalListAsync();
                Goals.Clear();
                foreach (var g in goals)
                {
                    Goals.Add(g);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        [RelayCommand]
        async Task Disappearing()
        {
            try
            {
                // DoSomething
                var goal = await Database.GetGoalAsync(1);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        [RelayCommand]
        async Task AddGoalAsync()
        {
            try
            {
                await Shell.Current.GoToAsync($"{nameof(NewGoalPage)}", true, new Dictionary<string, object>
                                                                                {
                                                                                    { "string",  "New Goal"}
                                                                                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Goals Error: Button", $"Add habit button failed.", "OK");
            }
        }

        [RelayCommand]
        async Task GoalTappedAsync()
        {
            try
            {
                await Shell.Current.GoToAsync($"{nameof(DisplayGoalPage)}", true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Goals Error: Button", $"Tap Goal Gesture Failed.", "OK");
            }
        }
    }
}
