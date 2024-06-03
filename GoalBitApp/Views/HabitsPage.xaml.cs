namespace GoalBitApp;

public partial class HabitsPage : ContentPage
{
	public HabitsPage(HabitsViewModel _viewModel)
	{
		InitializeComponent();

		BindingContext = _viewModel;
	}
}