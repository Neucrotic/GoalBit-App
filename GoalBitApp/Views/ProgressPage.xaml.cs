namespace GoalBitApp;

public partial class ProgressPage : ContentPage
{
	public ProgressPage(GoalsViewModel _viewModel)
	{
		InitializeComponent();

		BindingContext = _viewModel;
	}
}