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
            builder.Services.AddSingleton<HabitsViewModel>();
            builder.Services.AddSingleton<GoalsViewModel>();
            builder.Services.AddSingleton<ProgressViewModel>();

            builder.Services.AddSingleton<NewHabitViewModel>();

            builder.Services.AddSingleton<HabitsPage>();
            builder.Services.AddTransient<NewHabitPage>();

            builder.Services.AddSingleton<GoalsPage>();
            builder.Services.AddSingleton<ProgressPage>();

            return builder.Build();
        }
    }
}