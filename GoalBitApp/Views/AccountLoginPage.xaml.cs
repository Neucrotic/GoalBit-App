using GoalBitApp.ViewModel;

namespace GoalBitApp.Views;

public partial class AccountLoginPage : ContentPage
{
	public AccountLoginPage(AccountLoginViewModel _viewmodel)
	{
		InitializeComponent();
		BindingContext = _viewmodel;
	}
}