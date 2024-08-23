using AppGoalBit.ViewModel;

namespace AppGoalBit.Views;

public partial class NewHabitPage : ContentPage
{
	public NewHabitPage(NewHabitViewModel _viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel;
	}
}