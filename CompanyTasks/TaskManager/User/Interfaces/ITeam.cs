namespace TaskManager.User.Interfaces
{
    using System;
    using System.Collections.Generic;

    using Task.Interfaces;

    interface ITeam
    {
        void AddEmployee(IEmployee employee);

        void AddTasks(IEmployee employee, IToDo task);

        IDictionary<IEmployee, ICollection<IToDo>> EmployeeTasks { get; }

        IEnumerable<IEmployee> GetAllEmployees { get; }

        IEnumerable<IToDo> GetTasks(IEmployee employee);

        string TeamName { get; }
    }
}
