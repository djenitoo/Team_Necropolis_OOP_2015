namespace TaskManager.Task
{
    using System;

    using Interfaces;
    using Enum;
    using Validation;
    using Common;

    class ReminderSubTask : Subtask, ISubtask
    {
        private readonly ReminderDateValidator validator = new ReminderDateValidator();
        private DateTime reminderTime;


        public ReminderSubTask(string initTitle, string initDescription, PriorityType initPriority, DateTime dueDate, DateTime timeToRemind)
            : base(initTitle, initDescription, initPriority, dueDate)
        {
            this.TimeToRemind = timeToRemind;
        }

        public delegate void ReminderEventHandler(object source, EventArgs e);

        public event ReminderEventHandler ReminderTimeReached;

        public DateTime TimeToRemind
        {
            get
            {
                return this.reminderTime;
            }

            set
            {
                 // Check if the Reminder DateTime is not later than Task end DateTime
                validator.CheckReminderDate(this.DueDate, value);
                this.reminderTime = this.DueDate.Subtract(this.DueDate - value);
            }
        }

        public void CheckRemider()
        {
            if (DateTime.Now.CompareTo(this.TimeToRemind) >= 0)
            {
                OnReminderTimeReached();
            }
        }

        protected virtual void OnReminderTimeReached()
        {
            if (ReminderTimeReached != null)
            {
                ReminderTimeReached(this, EventArgs.Empty);
            }
        }
    }
}