namespace TaskManager.Task
{
    using Enum;
    using Interfaces;

    using System;
    using Common;
    using Validation;

    public class Subtask : ISubtask
    {
        private readonly ITaskValidation validation = new TaskValidation();

        private string title;
        private string description;
        private DateTime dueDate;

        public Subtask(string initTitle, string initDescription, PriorityType initPriority, DateTime dueDate)
        {
            this.Title = initTitle;
            this.Priority = initPriority;
            this.DateCreated = DateTime.Now;
            this.DueDate = dueDate;
            this.Description = initDescription;
        }

        public PriorityType Priority { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime DateCreated { get; private set; }

        public DateTime DueDate
        {
            get
            {
                return this.dueDate;
            }
            set
            {
                this.dueDate = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                this.validation.ValidateTitle(value, "Title");

                this.title = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                this.validation.ValidateDescription(value, "Descriptyon");

                this.description = value;
            }
        }

        protected ITaskValidation Validation
        {
            get { return this.validation; }
        }

        public override string ToString()
        {
            return string.Format("ToDo {0} - Title {1} , Description {2}", this.GetType().Name, this.title, this.description);
        }
    }
}
