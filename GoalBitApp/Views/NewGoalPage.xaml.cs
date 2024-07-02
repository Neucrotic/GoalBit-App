using GoalBitApp.ViewModel;

namespace GoalBitApp.Views;

public partial class NewGoalPage : ContentPage
{
	public NewGoalPage(NewGoalViewModel _viewmodel)
	{
		InitializeComponent();
		BindingContext = _viewmodel;
	}
}