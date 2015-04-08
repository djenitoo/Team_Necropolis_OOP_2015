namespace TaskManager.Task
{
    using System;
    using Enum;

    public class ImportantToDo : ToDo
    {
        private const int InitialDaysToEnd = 14;
        private const PriorityType InitialType = PriorityType.Important;

        public ImportantToDo(string initTitle, string initDescription)
            : base(initTitle, initDescription, InitialType, DateTime.Now.AddDays(InitialDaysToEnd))
        {
        }
    }
}
