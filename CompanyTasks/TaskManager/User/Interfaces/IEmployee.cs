namespace TaskManager.User.Interfaces
{
    using System;
    using Enums;
    using System.Collections.Generic;
    using Task.Interfaces;

    public interface IEmployee : IPerson
    {
        decimal Salary { get; }

        DateTime DateHired { get; }

        int ServiceInCompany { get; }

        PositionType Position { get; set; }

        ICollection<IToDo> PersonalTodos { get;}

        void RemovePersonalTodo(IToDo item);
        void AddPersonalTodo(IToDo item);
        void EmptyPersonalTodos();
    }
}
