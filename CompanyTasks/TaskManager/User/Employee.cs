/*
 * Employees are humans with more charateristics
 */

namespace TaskManager.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Common;
    using Enums;
    using User.Interfaces;
    using Task.Interfaces;

    public class Employee : Person, IEmployee
    {

        private const decimal MinSalaty = 900M;
        private const string GeneralToStringFormat = "Position: {0}, Salary: {1}, Time Worked: {2}";

        private decimal salary;
        private DateTime dateHired;
        private ICollection<IToDo> personalTodos;
        public bool IsPromoted { get; set; }

        public Employee(string name, DateTime dateBirth, Gender sex, PositionType position, DateTime dateHired, decimal salary)
            : base(name, dateBirth, sex)
        {
            this.Position = position;
            this.DateHired = dateHired;
            this.Salary = salary;

            this.personalTodos = new List<IToDo>();
        }

        public ICollection<IToDo> PersonalTodos
        {
            get
            {
                return new List<IToDo>(this.personalTodos);
            }
        }

        public DateTime DateHired
        {
            get
            {
                return this.dateHired;
            }

            private set
            {
                this.Validation.ValidateDateHired(value);

                this.dateHired = value;
            }
        }

        public PositionType Position { get; set; }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            private set
            {
                this.Validation.ValidateSalary(value);

                this.salary = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            result.AppendLine(string.Format(Employee.GeneralToStringFormat, this.Position, this.Salary, this.DateHired));
            return result.ToString();
        }

        public int ServiceInCompany
        {
            get
            {
                return (DateTime.Now - this.DateHired).Days;
            }
        }
        
        public void RemovePersonalTodo(IToDo item)
        {
            if (this.personalTodos.Contains(item))
            {
                this.personalTodos.Remove(item);
            }
            
            
        }

        public void AddPersonalTodo(IToDo item)
        {
            if (!(this.personalTodos.Contains(item)))
            {
                this.personalTodos.Add(item);
            }
            
        }

        public void EmptyPersonalTodos()
        {
            this.personalTodos = new List<IToDo>();
        }
    }
}
