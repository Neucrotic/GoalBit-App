using AppGoalBit.ViewModel;

namespace AppGoalBit.Views;

public partial class NewGoalPage : ContentPage
{
	public NewGoalPage(NewGoalViewModel _viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel;
	}
}