using GoalBitApp.ViewModel;

namespace GoalBitApp.Views;

public partial class LinkHabitToGoalsPage : ContentPage
{
	public LinkHabitToGoalsPage(LinkHabitToGoalsViewModel _viewmodel)
	{
		InitializeComponent();
		BindingContext = _viewmodel;
	}
}