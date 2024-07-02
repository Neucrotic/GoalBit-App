using GoalBitApp.ViewModel;

namespace GoalBitApp.Views;

public partial class DisplayGoalPage : ContentPage
{
	public DisplayGoalPage(DisplayGoalViewModel _viewmodel)
	{
		InitializeComponent();
		BindingContext = _viewmodel;
	}
}