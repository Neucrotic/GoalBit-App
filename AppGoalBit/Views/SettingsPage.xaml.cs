using AppGoalBit.ViewModel;

namespace AppGoalBit.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel _viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel;
	}

    private void themeSwitch_Toggled(object sender, ToggledEventArgs e)
    {
		if (e.Value)
		{
			Application.Current.UserAppTheme = AppTheme.Dark;
		}
		else
		{
			Application.Current.UserAppTheme = AppTheme.Light;
        }
    }
}