using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalBitApp.Model
{
    public class UserAccount
    {
        AccountData accountData;
        UserSettings settings;

        public ObservableCollection<Habit> Habits { get; } = new();

        public UserAccount() { }
    }
}
