namespace TaskManager.Task.Interfaces
{
    using Enum;

    using System;
    using System.Collections.Generic;

    public interface IToDo : ISubtask
    {
        ICollection<IComment> Comments { get; }

        StatusType Status { get; set; }

        ICollection<ISubtask> Subtasks { get; }

        void CompleteToDo();
    }
}
