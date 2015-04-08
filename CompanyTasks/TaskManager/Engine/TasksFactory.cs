namespace TaskManager.Engine
{
    using System;
    using System.Collections.Generic;

    using Task;
    using Task.Interfaces;
    using Task.Enum;
    
    public class TasksFactory
    {
        public IToDo CreateImportantToDo(string initTitle, string initDescription)
        {
            return new ImportantToDo(initTitle, initDescription);
        }

        public IToDo CreateLowToDo(string initTitle, string initDescription)
        {
            return new LowToDo(initTitle, initDescription);
        }

        public IToDo CreateMediumToDo(string initTitle, string initDescription)
        {
            return new MediumToDo(initTitle, initDescription);
        }
    }
}
