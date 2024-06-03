using GoalBitApp.ViewModel;

namespace GoalBitApp.Views;

public partial class NewHabitPage : ContentPage
{
	public NewHabitPage(NewHabitViewModel _viewmodel)
	{
		InitializeComponent();
        BindingContext = _viewmodel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}