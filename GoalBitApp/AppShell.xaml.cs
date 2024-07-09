using GoalBitApp.Views;

namespace GoalBitApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(NewHabitPage), typeof(NewHabitPage));
            Routing.RegisterRoute(nameof(NewGoalPage), typeof(NewGoalPage));
            Routing.RegisterRoute(nameof(DisplayGoalPage), typeof(DisplayGoalPage));
            Routing.RegisterRoute(nameof(HabitsPage), typeof(HabitsPage));
            // estimating 21 routes total, this does not include going 'back' on android
        }
    }
}