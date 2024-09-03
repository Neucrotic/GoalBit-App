using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using AppGoalBit.Data;
using AppGoalBit.Views;
using AppGoalBit.ViewModel;

namespace AppGoalBit
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            // Set up registration for Data Services
            builder.Services.AddSingleton<GBDatabase>();

            // Register a ViewModel for each View
            builder.Services.AddSingleton<GoalsViewModel>();
            builder.Services.AddSingleton<HabitsViewModel>();
            builder.Services.AddSingleton<ProgressViewModel>();
            builder.Services.AddSingleton<SettingsViewModel>();

            builder.Services.AddSingleton<NewGoalViewModel>();
            builder.Services.AddSingleton<DisplayGoalViewModel>();
            builder.Services.AddSingleton<NewHabitViewModel>();
            builder.Services.AddSingleton<LinkHabitsViewModel>();

            //Register Views
            builder.Services.AddSingleton<GoalsPage>();
            builder.Services.AddSingleton<HabitsPage>();
            builder.Services.AddSingleton<ProgressPage>();
            builder.Services.AddSingleton<SettingsPage>();

            builder.Services.AddTransient<NewGoalPage>();
            builder.Services.AddTransient<LinkHabitsPage>();
            builder.Services.AddTransient<DisplayGoalPage>();
            builder.Services.AddTransient<NewHabitPage>();

            return builder.Build();
        }
    }
}
