namespace TaskManager.Task
{
    using System;
    using Enum;

    public class LowToDo : ToDo
    {
        private const int InitialDaysToEnd = 60;
        private const PriorityType InitialType = PriorityType.Low;

        public LowToDo(string initTitle, string initDescription)
            : base(initTitle, initDescription, InitialType, DateTime.Now.AddDays(InitialDaysToEnd))
        {
        }

        
    }
}
