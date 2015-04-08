namespace TaskManager.Task
{
    using Enum;
    using Interfaces;

    using System;
    using System.Linq;
    using System.Collections.Generic;

    public abstract class ToDo : Subtask, IToDo
    {
        private ICollection<ISubtask> subTasks;
        private ICollection<IComment> comments;

        public ToDo(string initTitle, string initDescription, PriorityType initPriority, DateTime dueDate)
            : base(initTitle, initDescription, initPriority, dueDate)
        {
            this.Status = StatusType.Launched;
            this.subTasks = new List<ISubtask>();
            this.comments = new List<IComment>();
        }

        public ICollection<ISubtask> Subtasks
        {
            get { return new List<ISubtask>(this.subTasks); }
        }

        public ICollection<IComment> Comments
        {
            get { return new List<IComment>(this.comments); }
        }

        public StatusType Status { get; set; }

        public void AddSubtask(ISubtask subtask)
        {
            this.Validation.SubtaskNotFound(subtask);

            this.subTasks.Add(subtask);
        }

        public void AddComment(IComment comment)
        {
            if (!(comments.Contains(comment)))
            {
                this.comments.Add(comment);
            }
        }

        public void CompleateSubtask(ISubtask subtask)
        {
            var compleatedSubtask = this.subTasks.First(task => task.Title == subtask.Title);

            this.Validation.SubtaskNotFound(compleatedSubtask);

            compleatedSubtask.IsCompleted = true;
        }

        public void RemoveSubtask(ISubtask subtask)
        {
            var deletedSubtask = this.subTasks.First(task => task.Title == subtask.Title);

            this.Validation.SubtaskNotFound(deletedSubtask);

            this.subTasks.Remove(deletedSubtask);
        }

        public void CompleteToDo()
        {
            this.IsCompleted = false;
            this.Status = StatusType.Finished;
        }

        public void EmptyComments()
        {
            this.comments = new List<IComment>();
        }
        public void EmptySubTasks()
        {
            this.subTasks = new List<ISubtask>();
        }
        // also maybe method to delete todo(not isdone)
    }
}
