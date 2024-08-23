using AppGoalBit.Views;

namespace AppGoalBit
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register Page Routing Here
            Routing.RegisterRoute(nameof(NewHabitPage), typeof(NewHabitPage));
            Routing.RegisterRoute(nameof(NewGoalPage), typeof(NewGoalPage));
            Routing.RegisterRoute(nameof(DisplayGoalPage), typeof(DisplayGoalPage));
            Routing.RegisterRoute(nameof(HabitsPage), typeof(HabitsPage));
        }
    }
}
