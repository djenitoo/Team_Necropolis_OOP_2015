namespace TaskManager.User
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using User.Interfaces;

    public class Client : Person, IClient
    {

        public List<string> MyProjectsTodo { get; private set; }
        public string ClientCompany { get; private set; }

        public Client(string name, string clientCompany, IEnumerable<string> myProjectTodo, DateTime dateBirth, Gender sex)
            :base (name, dateBirth, sex)
        {
            this.ClientCompany = clientCompany;
            this.MyProjectsTodo = myProjectTodo.ToList();
        }

        public void AddProject(string project)
        {
            if (!(this.MyProjectsTodo.Contains(project)))
            {
                this.MyProjectsTodo.Add(project);
            }
            //implement handler for adding existing project
        }

        public void RemoveProject(string project)
        {
            if (this.MyProjectsTodo.Contains(project))
            {
                this.MyProjectsTodo.Remove(project);
            }
            //implement handler for missing project for removing
        }

        public void EmptyProjects()
        {
            this.MyProjectsTodo = new List<string>();
        }
    }
}
