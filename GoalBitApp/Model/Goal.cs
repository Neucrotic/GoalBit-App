using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalBitApp.Model
{
    public class Goal
    {
        public int ID { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Habit> LinkedHabits { get; set; }
        public float ProgressPercentage { get; set; }//This must be between 0 and 1

        public Goal(int _id, string _name, string _description)
        {
            ID = _id;
            Name = _name;
            Description = _description;

            LinkedHabits = new();

            ProgressPercentage = 0.5f;
        }
    }
}
