using GoalBitApp.ViewModel;

namespace GoalBitApp.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel _viewmodel)
	{
		InitializeComponent();
		BindingContext = _viewmodel;
	}
}