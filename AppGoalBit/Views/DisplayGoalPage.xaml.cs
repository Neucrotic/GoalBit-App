using AppGoalBit.ViewModel;

namespace AppGoalBit.Views;

public partial class DisplayGoalPage : ContentPage
{
	public DisplayGoalPage(DisplayGoalViewModel _viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel;
	}
}