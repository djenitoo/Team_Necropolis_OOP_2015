namespace TaskManager.Task
{
    using System;

    using Interfaces;

    public class TestReminderSubscriber : ISubscriber
    {
        public void OnReminderTimeReached(object sourse, EventArgs e)
        {
            Console.WriteLine("Reminder Alert....");
        }
    }
}