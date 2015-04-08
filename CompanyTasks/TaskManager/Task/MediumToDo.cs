namespace TaskManager.Task
{
    using System;
    using Enum;

    public class MediumToDo : ToDo
    {
        private const int InitialDaysToEnd = 30;
        private const PriorityType InitialType = PriorityType.Important;

        public MediumToDo(string initTitle, string initDescription)
            : base(initTitle, initDescription, InitialType,DateTime.Now.AddDays(InitialDaysToEnd))
        {
        }
    }
}
