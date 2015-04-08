﻿namespace TaskManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Task;
    using User;
    using User.Enums;


    public class TaskManager
    {
        public static void Main()
        {
            // Example of the functionality that is not yet in the engine
            var manager = new TeamLeader("Kir4o", new DateTime(1968, 05, 20), Gender.Male, new DateTime(1999, 05, 20), new Team("Kir4osTeam"));
            var employee = new JuniorEmployee("Petra", new DateTime(1988, 12, 01), Gender.Female, new DateTime(2005, 09, 05));
            var newEmp = new SeniorEmployee("Stamat", new DateTime(1986, 01, 30), Gender.Male, new DateTime(2002, 07, 16));

            manager.Team.AddEmployee(employee);
            manager.Team.AddEmployee(newEmp);
            Console.WriteLine("Initial Team:");
            Console.WriteLine(manager.ToString());
            Console.WriteLine(string.Join("\n", manager.Team.GetAllEmployees));

            //the manager promote perta from junior to senior;
            manager.Promote(employee);
            var employee2 = employee.PromotedToSinior(employee, employee.IsPromoted);

            //this should be implemented into the classes -> there must be a virtual method so that every kind of employee (i.e. junior, seniro or manager) coulbe be promoted
            manager.Team.RemoveEmployee(employee);
            manager.Team.AddEmployee(employee2);

            Console.WriteLine("Petra was promoted to senior");
            Console.WriteLine(manager.ToString());
            Console.WriteLine(string.Join("\n", manager.Team.GetAllEmployees));

            //the manager promote stamat from senior to manager
            manager.Promote(newEmp);
            var men2 = newEmp.PromotedToManager(newEmp, newEmp.IsPromoted);
            manager.Team.RemoveEmployee(newEmp);

            Console.WriteLine("Stamat became a manager:");
            Console.WriteLine(men2.ToString());
            Console.WriteLine(manager.ToString());
            Console.WriteLine(string.Join("\n", manager.Team.GetAllEmployees));

            //manager.Team.AddTasks(employee, new LowToDo("Create web site", new string('s', 30)));

            //var tasks = manager.Team.GetTasks(employee);

            //foreach (var task in tasks)
            //{
            //    Console.WriteLine(task);
            //}

            //Test Event
            var someSubtask = new ReminderSubTask("Test Reminder Task",  "Some describtion that is longer than 20",  Task.Enum.PriorityType.Important, new DateTime(2015, 4, 4, 22, 55, 0), new DateTime(2015, 4, 4, 22, 53, 0)); // sender
            var someSubscriber = new TestReminderSubscriber(); // Subscriber

            someSubtask.ReminderTimeReached += someSubscriber.OnReminderTimeReached; //subscribtion happens here
            
            ////Uncomment to Checks If Reminder Works 
            //while (true)
            //{
            //    someSubtask.CheckRemider();
            
            //}

            // E N G I N E
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\r\n \t\t Beginning of Engine: ");
            Console.ResetColor();
            Engine.TaskManagerEngine.Instance.Start();

            // Example command for new boss :       CreateBoss Miro 1966/12/04 male 1999/02/12 25000
            // Example command for new team leader: CreateTeamLeader Dobri 1980/03/06 male 2008/08/07 TeamDobri
            // Example command for new Junior:      CreateJuniorEmployee Rosen 1990/06/05 male 2010/08/10
            // Example command for new Senior:      CreateSeniorEmployee Maria 1986/11/12 female 2008/06/07
            // Example command for new Imp. todo:   CreateImportantToDo SomeTitleOfTodo SomeDescrOfTodo
            // Example command for new Med. todo:   CreateMediumToDo SomeOtherTitleOfTodo SomeOtherDescrOfTodo
            // Example command for new Low todo:    CreateLowToDo SomeOtherTitleOfTodo SomeOtherDescrOfTodo

        }
    }
}
