using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalBitApp.Model
{
    public class Habit
    {
        public int ID { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Streak { get; set; }

        public Habit(int _id, string _name, string _description)
        {
            ID = _id;
            Name = _name;
            Description = _description;
            Streak = 0;
        }
    }
}
