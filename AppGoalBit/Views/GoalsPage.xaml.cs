using AppGoalBit.ViewModel;

namespace AppGoalBit.Views;

public partial class GoalsPage : ContentPage
{
	public GoalsPage(GoalsViewModel _viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel;
    }
}