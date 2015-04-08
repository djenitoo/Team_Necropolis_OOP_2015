namespace TaskManager.User.Interfaces
{
    using System;
    using Enums;

    public interface IPerson
    {
        string Name { get; }

        Gender Sex { get; }

        DateTime DateBirth { get; }
    }
}
