﻿using AndroidX.Core.Util;
using AppGoalBit.Data;
using AppGoalBit.Model;
using AppGoalBit.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGoalBit.ViewModel
{
    public partial class HabitsViewModel : ObservableObject
    {
        public ObservableCollection<Habit> Habits { get; } = new();
        List<Habit> ConfirmedHabits = new();
        GBDatabase Database;

        public HabitsViewModel(GBDatabase _database)
        {
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
                    foreach (var g in habits)
                    {
                        Habits.Add(g);
                    }
                });
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
                // Do database CRUD
                foreach (var h in Habits)
                {
                    await Database.SaveHabitAsync(h);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        [RelayCommand]
        async Task AddHabitAsync(Habit _habit)
        {
            try
            {
                if (_habit is null)
                {
                    _habit = new();
                    _habit.Name = "Name";
                    _habit.Description = "Describe your habit here.";
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
            try
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
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                await Shell.Current.DisplayAlert("Habits Error: Swipe", $"Edit Habit Failed", "OK");
            }
        }

        [RelayCommand]
        async Task ConfirmHabitAsync(Habit _habit)
        {
            bool answer = false;
            try
            {
                answer = await Shell.Current.DisplayAlert("Confirm?", "Have you maintained this habit today?", "Yes", "No");
                if (answer)
                {
                    // Do database CRUD
                    _habit.Done = true;
                    await Database.SaveHabitAsync(_habit);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                await Shell.Current.DisplayAlert("Habits Error: Tap", $"Error Confirming Habit", "OK");
            }
            finally
            {
                // Do local update after database CRUD successful
                if (answer)
                {
                    Habits.Remove(_habit);
                }
                
            }
        }
    }
}
