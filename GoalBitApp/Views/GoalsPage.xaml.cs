namespace GoalBitApp;

public partial class GoalsPage : ContentPage
{
	public GoalsPage(GoalsViewModel _viewModel)
	{
		InitializeComponent();

		BindingContext = _viewModel;
	}
}