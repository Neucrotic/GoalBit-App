using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGoalBit.Model
{
    public class Habit
    {
        public int ID { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Streak { get; set; }

        public Habit() { }
    }
}
