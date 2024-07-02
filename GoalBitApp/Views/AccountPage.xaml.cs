using GoalBitApp.ViewModel;

namespace GoalBitApp.Views;

public partial class AccountPage : ContentPage
{
	public AccountPage(AccountViewModel _viewmodel)
	{
		InitializeComponent();
		BindingContext = _viewmodel;
	}
}