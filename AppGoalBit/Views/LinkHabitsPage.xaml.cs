using AppGoalBit.ViewModel;

namespace AppGoalBit.Views;

public partial class LinkHabitsPage : ContentPage
{
	public LinkHabitsPage(LinkHabitsViewModel _viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel;
	}
}