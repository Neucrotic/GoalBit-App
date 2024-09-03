using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppGoalBit.Model;
using SQLite;

namespace AppGoalBit.Data
{
    public class GBDatabase
    {
        SQLiteAsyncConnection Database;

        public GBDatabase()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

            // I think result is used as a debugging variable that is scrapped when we exit this code block.
            var result = await Database.CreateTableAsync<Goal>();
            result = await Database.CreateTableAsync<Habit>();
        }

        public async Task<List<Goal>> GetGoalListAsync()
        {
            await Init();
            return await Database.Table<Goal>().ToListAsync();
        }

        public async Task<List<Habit>> GetHabitListAsync()
        {
            await Init();
            return await Database.Table<Habit>().ToListAsync();
        }

        public async Task<Goal> GetGoalAsync(int _id)
        {
            await Init();
            return await Database.Table<Goal>().Where(i => i.ID == _id).FirstOrDefaultAsync();
        }

        public async Task<Habit> GetHabitAsync(int _id)
        {
            await Init();
            return await Database.Table<Habit>().Where(i => i.ID == _id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveGoalAsync(Goal _goal)
        {
            await Init();

            // Check if Goal exists. Update or Insert
            if (_goal.ID != 0)
            {
                return await Database.UpdateAsync(_goal);
            }
            else
            {
                return await Database.InsertAsync(_goal);
            }   
        }

        public async Task<int> SaveHabitAsync(Habit _habit)
        {
            await Init();
            if (_habit.ID != 0)
            {
                return await Database.UpdateAsync(_habit);
            }
            else
            {
                return await Database.InsertAsync(_habit);
            }
        }

        public async Task<int> DeleteGoalAsync(Goal _goal)
        {
            await Init();
            return await Database.DeleteAsync(_goal);
        }

        public async Task<int> DeleteHabitAsync(Habit _habit)
        {
            await Init();
            return await Database.DeleteAsync(_habit);
        }

        public async Task WipeDatabaseClean()
        {
            try
            {
                TableMapping habitTable = await Database.GetMappingAsync<Habit>();
                TableMapping goalTable = await Database.GetMappingAsync<Goal>();

                await Database.DeleteAllAsync(habitTable);
                await Database.DeleteAllAsync(goalTable);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Database Error: Button", $"Failed to reset database.", "OK");
            }
            finally
            {
                await LoadGoalBitTutorialData();
            }
        }

        private async Task LoadGoalBitTutorialData()
        {
            TableMapping habitTable = await Database.GetMappingAsync<Habit>();
            TableMapping goalTable = await Database.GetMappingAsync<Goal>();

            try
            {
                Habit habit = new();
                Goal goal = new();

                habit.Name = "Daily Habits";
                habit.Description = "Habits reset daily and contribute progress towards any goals they are linked to.\n" +
                    "Complete habits by tapping on them or edited by swiping left.\n" +
                    "You can either delte or edit this habit when you are ready.";
                habit.Streak = 10;

                goal.Name = "Longterm Goals";
                goal.Description = "Longterm goals can take time to achieve. Tap on a goal to view the habits it is linked to as well as edit or delete the goal." +
                    "\nTry deleting this goal now.";

                await SaveHabitAsync(habit);
                await SaveGoalAsync(goal);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Database Error: Button", $"Failed to load tutorial habits and goals.", "OK");
            }
        }
    }
}
