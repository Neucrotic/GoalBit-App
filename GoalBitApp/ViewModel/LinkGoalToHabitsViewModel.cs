using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalBitApp.ViewModel
{
    public partial class LinkGoalToHabitsViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;

        public LinkGoalToHabitsViewModel()
        {
            Title = "Link a Goal to Habits";
        }
    }
}
