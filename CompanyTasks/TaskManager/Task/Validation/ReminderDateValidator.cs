namespace TaskManager.Task.Validation
{
    using System;
    using Common;

    public class ReminderDateValidator : CommonValidation
    {
        private const string ErrMessageReminderDate = "The reminder date cannot be later than the end date.";
        public void CheckReminderDate(DateTime endDate, DateTime reminderDate)
        {
            if (endDate.CompareTo(reminderDate) <= 0)
            {
                throw new ArgumentException(ErrMessageReminderDate);
            }
        }
    }
}