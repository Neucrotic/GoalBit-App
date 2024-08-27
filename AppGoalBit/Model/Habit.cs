using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGoalBit.Model
{
    public class Habit
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int GoalKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Streak { get; set; }
        public bool Done { get; set; }
        public bool HasLink { get; set; }
    }
}
