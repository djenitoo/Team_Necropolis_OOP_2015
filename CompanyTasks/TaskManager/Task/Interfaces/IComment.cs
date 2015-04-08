namespace TaskManager.Task.Interfaces
{
    using System;
    using User.Interfaces;

    public interface IComment
    {
        string Content { get; }

        DateTime DateCreated { get; }

        IPerson Author { get; }
    }
}
