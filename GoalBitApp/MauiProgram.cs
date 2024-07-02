using GoalBitApp.ViewModel;
using GoalBitApp.Views;
using Microsoft.Extensions.Logging;

namespace GoalBitApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            // Set up registration for Services
            // ...

            // Set up ViewModel for each View
            builder.Services.AddSingleton<AccountLoginViewModel>();
            builder.Services.AddSingleton<AccountViewModel>();
            builder.Services.AddSingleton<DisplayGoalViewModel>();
            builder.Services.AddSingleton<GoalsViewModel>();
            builder.Services.AddSingleton<HabitsViewModel>();
            builder.Services.AddSingleton<LinkGoalToHabitsViewModel>();
            builder.Services.AddSingleton<LinkGoalToHabitsViewModel>();
            builder.Services.AddSingleton<NewGoalViewModel>();
            builder.Services.AddSingleton<NewHabitViewModel>();
            builder.Services.AddSingleton<ProgressViewModel>();
            builder.Services.AddSingleton<SettingsViewModel>();

            // Set up 11 Views
            builder.Services.AddSingleton<AccountLoginPage>();
            builder.Services.AddSingleton<AccountPage>();
            builder.Services.AddTransient<DisplayGoalPage>();
            builder.Services.AddSingleton<GoalsPage>();
            builder.Services.AddSingleton<HabitsPage>();
            builder.Services.AddTransient<LinkGoalToHabitsPage>();
            builder.Services.AddTransient<LinkHabitToGoalsPage>();
            builder.Services.AddSingleton<NewGoalPage>();
            builder.Services.AddTransient<NewHabitPage>();
            builder.Services.AddSingleton<ProgressPage>();
            builder.Services.AddSingleton<SettingsPage>();

            return builder.Build();
        }
    }
}