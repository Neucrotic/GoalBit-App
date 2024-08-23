using AppGoalBit.ViewModel;

namespace AppGoalBit.Views;

public partial class ProgressPage : ContentPage
{
	public ProgressPage(ProgressViewModel _viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel;
    }
}