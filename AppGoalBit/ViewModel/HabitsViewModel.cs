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

            Habit habit1 = new();
            habit1.Name = "Read";
            habit1.Description = "Read at least 1 chapter of any book.";
            Habit habit2 = new();
            habit2.Name = "Write";
            habit2.Description = "Write until the word count goal has been reached.";
            Habit habit3 = new();
            habit3.Name = "Code";
            habit3.Description = "Work on a feature of the current app you are developing.";

            Habits.Add(habit1);
            Habits.Add(habit2);
            Habits.Add(habit3);

            CheckForNullHabits();
            CheckTimeForHabitListRefresh();
        }

        [RelayCommand]
        void Appearing()
        {
            try
            {

                // DoSomething

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        [RelayCommand]
        void Disappearing()
        {
            try
            {

                // DoSomething

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
        async Task DeleteHabitAsync(Habit _habit)
        {
            try
            {
                Habits.Remove(_habit);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                await Shell.Current.DisplayAlert("Habits Error: Swipe", $"Delete Habit Failed", "OK");
            }
        }

        [RelayCommand]
        async Task ConfirmHabitAsync(Habit _habit)
        {
            bool answer = false;
            try
            {
                answer = await Shell.Current.DisplayAlert("Confirm?", "Have you maintained this habit today?", "Yes", "No");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                await Shell.Current.DisplayAlert("Habits Error: Tap", $"Error Confirming Habit", "OK");
            }
            finally
            {
                if (answer)
                {
                    UserCompletedHabit(_habit);
                }
            }
        }

        void UserCompletedHabit(Habit _habit)
        {
            ConfirmedHabits.Add(_habit);
            Habits.Remove(_habit);
        }

        void CheckForNullHabits()
        {
            foreach (var h in Habits)
            {
                if (h.Name == "null")
                    Habits.Remove(h);
            }
        }

        void CheckTimeForHabitListRefresh()
        {
                
        }

        void RefreshHabitLists()
        {
            foreach (var h in ConfirmedHabits)
            {
                Habits.Add(h);
            }

            ConfirmedHabits.Clear();
        }
    }
}
