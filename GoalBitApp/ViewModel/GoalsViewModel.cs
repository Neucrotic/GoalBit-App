using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using GoalBitApp.Model;
using System.Collections.ObjectModel;
using GoalBitApp.Views;

namespace GoalBitApp
{
    public partial class GoalsViewModel : ObservableObject
    {
        public ObservableCollection<Goal> Goals { get; } = new();

        public GoalsViewModel()
        {
            Goal goal1 = new Goal(1, "Financial Freedom Through Coding Apps", "I want to use my coding skills to build apps which I can market and monotize in order to quit my day job and mak art full time.");
            Goal goal2 = new Goal(2, "Write a Book", "By incrementally working through each section of a story, I want to finnaly write a work of fiction in the novel format. Even if it is never published is it an important first step.");

            Goals.Add(goal1);
            Goals.Add(goal2);
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
