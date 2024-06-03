using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GoalBitApp
{
    public partial class GoalsViewModel : ObservableObject
    {
        public GoalsViewModel()
        {

        }

        [RelayCommand]
        async Task AddGoalAsync()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Goals Error: Button", $"Add habit button failed.", "OK");
            }
        }
    }
}
