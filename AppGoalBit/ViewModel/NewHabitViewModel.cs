﻿using AppGoalBit.Data;
using AppGoalBit.Model;
using AppGoalBit.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGoalBit.ViewModel
{
    [QueryProperty("Habit", "Habit")]
    [QueryProperty("Title", "string")]
    [QueryProperty("IsDeleteVisible", "bool")]
    public partial class NewHabitViewModel : ObservableObject
    {
        [ObservableProperty]
        Habit habit;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        bool isDeleteVisible;

        GBDatabase Database;

        public NewHabitViewModel(GBDatabase _database)
        {
            Database = _database;
        }

        [RelayCommand]
        async Task UpdateNameAsync()
        {
            try
            {
                //Habit.Name = _e.Text;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Habits Error: Update Habit", $"Error updated habit name.", "OK");
            }
        }

        [RelayCommand]
        async Task UpdateDescriptionAsync(string _desc)
        {
            try
            {
                Habit.Description = _desc;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Habits Error: Update Habit", $"Error updated habit name.", "OK");
            }
        }

        [RelayCommand]
        async Task ConfirmHabitAsync()
        {
            try
            {
                // Do database CRUD
                await Database.SaveHabitAsync(Habit);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Habits Error: New Habit", $"Error editing or creating a habit.", "OK");
            }
            finally
            {
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        async Task DeleteHabitAsync()
        {
            try
            {
                // Do database CRUD
                await Database.DeleteHabitAsync(Habit);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Habits Error: Delete Habit", $"Error deleting a habit.", "OK");

            }
            finally
            {
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
