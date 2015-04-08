namespace TaskManager.User
{
    using System.Collections.Generic;

    using Interfaces;
    using Task.Interfaces;
    using Task;


    public class Team : ITeam
    {
        private string name;

        private IDictionary<IEmployee, ICollection<IToDo>> employeeTasks;

        public Team(string teamName)
        {
            this.employeeTasks = new Dictionary<IEmployee, ICollection<IToDo>>();
        }

        public string TeamName
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value;
            }
        }

        public IDictionary<IEmployee, ICollection<IToDo>> EmployeeTasks
        {
            get
            {
                return new Dictionary<IEmployee, ICollection<IToDo>>(this.employeeTasks);
            }
        }

        public IEnumerable<IEmployee> GetAllEmployees
        {
            get
            {
                return new List<IEmployee>(this.employeeTasks.Keys);
            }
        }

        public void AddEmployee(IEmployee employee)
        {
            this.employeeTasks.Add(employee, new List<IToDo>());
        }

        public void RemoveEmployee(IEmployee employee)
        {
            this.employeeTasks.Remove(employee);
        }

        public void AddTasks(IEmployee employee, IToDo task)
        {
            this.employeeTasks[employee].Add(task);
        }

        public IEnumerable<IToDo> GetTasks(IEmployee employee)
        {
            return new List<IToDo>(this.employeeTasks[employee]);
        }

    }
}
