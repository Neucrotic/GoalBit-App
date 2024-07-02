using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalBitApp.ViewModel
{
    public partial class AccountViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;

        public AccountViewModel()
        {
            Title = "Account";
        }
    }
}
