using GoalBitApp.Views;

namespace GoalBitApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(NewHabitPage), typeof(NewHabitPage));
        }
    }
}