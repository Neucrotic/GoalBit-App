using GoalBitApp.ViewModel;

namespace GoalBitApp.Views;

public partial class LinkGoalToHabitsPage : ContentPage
{
	public LinkGoalToHabitsPage(LinkGoalToHabitsViewModel _viewmodel)
	{
		InitializeComponent();
		BindingContext = _viewmodel;
	}
}