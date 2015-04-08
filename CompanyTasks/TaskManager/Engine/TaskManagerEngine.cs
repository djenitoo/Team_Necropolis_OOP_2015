namespace TaskManager.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using User;
    using User.Enums;
    using User.Interfaces;

    using Task;
    using Task.Enum;
    using Task.Interfaces;

    public class TaskManagerEngine
    {
        private const string InvalidCommand = "Invalid command name: {0}!";
        private const string UserCreated = "{0} with name {1} was created!";
        private const string TaskCreated = "{0} {1} successfully created!";
        private const string InvalidGenderType = "Invalid gender type!";


        private static readonly TaskManagerEngine SingleInstance = new TaskManagerEngine();

        private readonly UsersFactory userFactory;
        private readonly TasksFactory tasksFactory;

        private TaskManagerEngine()
        {
            this.userFactory = new UsersFactory();
            this.tasksFactory = new TasksFactory();
        }

        public static TaskManagerEngine Instance
        {
            get
            {
                return SingleInstance;
            }
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        private void PrintReports(IList<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
            }
            Console.Write(output.ToString());
        }

        private IList<Command> ReadCommands()
        {
            var commands = new List<Command>();

            var currentLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = Command.Parse(currentLine);
                commands.Add(currentCommand);

                currentLine = Console.ReadLine();
            }

            return commands;
        }

        private IList<string> ProcessCommands(IList<Command> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {
                    var report = this.ProcessSingleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }

        private string ProcessSingleCommand(Command command)
        {
            switch (command.Name)
            {
                case "CreateBoss":
                    var bossName = command.Parameters[0];
                    var bossBirth = DateTime.Parse(command.Parameters[1]);
                    var bossGender = this.GetGender(command.Parameters[2]);
                    var dateHired = DateTime.Parse(command.Parameters[3]);
                    var salary = Decimal.Parse(command.Parameters[4]);
                   
                    return this.CreateBoss(bossName, bossBirth, bossGender, dateHired, salary);

                case "CreateTeamLeader":
                    var teamLeaderName = command.Parameters[0];
                    var teamLeaderBirth = DateTime.Parse(command.Parameters[1]);
                    var teamLeaderGender = this.GetGender(command.Parameters[2]);
                    dateHired = DateTime.Parse(command.Parameters[3]);
                    var teamName = command.Parameters[4];

                    return this.CreateTeamLeader(teamLeaderName, teamLeaderBirth, teamLeaderGender, teamName, dateHired);

                case "CreateJuniorEmployee":
                    var name = command.Parameters[0];
                    var dateBirth = DateTime.Parse(command.Parameters[1]);
                    var gender = this.GetGender(command.Parameters[2]);
                    dateHired = DateTime.Parse(command.Parameters[3]);

                    return this.CreateJuniorEmployee(name, dateBirth, gender, dateHired);

                case "CreateSeniorEmployee":
                    name = command.Parameters[0];
                    dateBirth = DateTime.Parse(command.Parameters[1]);
                    gender = this.GetGender(command.Parameters[2]);
                    dateHired = DateTime.Parse(command.Parameters[3]);

                    return this.CreateSeniorEmployee(name, dateBirth, gender, dateHired);

                case "CreateImportantToDo":
                    var initTitle = command.Parameters[0];
                    var initDescription = command.Parameters[1];

                    return this.CreateImportantToDo(initTitle, initDescription);

                case "CreateMediumToDo":
                    initTitle = command.Parameters[0];
                    initDescription = command.Parameters[1];

                    return this.CreateMediumToDo(initTitle, initDescription);

                case "CreateLowToDo":
                    initTitle = command.Parameters[0];
                    initDescription = command.Parameters[1];

                    return this.CreateLowToDo(initTitle, initDescription);

                default:
                    return string.Format(InvalidCommand, command.Name);
            }
        }

        private string CreateLowToDo(string initTitle,string initDescription)
        {
            var lowTodo = this.tasksFactory.CreateLowToDo(initTitle, initDescription);

            return string.Format(TaskCreated, "Low Todo", initTitle);
        }

        private string CreateMediumToDo(string initTitle,string initDescription)
        {
            var mediumTodo = this.tasksFactory.CreateMediumToDo(initTitle, initDescription);
            return string.Format(TaskCreated, "Medium Todo", initTitle);
        }

        private string CreateImportantToDo(string initTitle, string initDescription)
        {
            var importantTodo = this.tasksFactory.CreateImportantToDo(initTitle, initDescription);

            return string.Format(TaskCreated, "Important Todo", initTitle);
        }

        private string CreateSeniorEmployee(string name, DateTime dateBirth, Gender gender, DateTime dateHired)
        {
            if (dateBirth >= dateHired)
            {
                throw new ArgumentOutOfRangeException("Date of senior of junior cannot be bigger than date hired!");
            }

            var senior = this.userFactory.CreateSeniorEmployee(name, dateBirth, gender, dateHired);

            return string.Format(UserCreated, "Senior", name);
        }

        private string CreateJuniorEmployee(string name, DateTime dateBirth, Gender gender, DateTime dateHired)
        {
            if (dateBirth >= dateHired)
            {
                throw new ArgumentOutOfRangeException("Date of birth of junior cannot be bigger than date hired!");
            }

            var junior = this.userFactory.CreateJuniorEmployee(name, dateBirth, gender, dateHired);

            return string.Format(UserCreated, "Junior", name); 
        }

        private string CreateTeamLeader(string teamLeaderName, DateTime teamLeaderBirth, Gender teamLeaderGender, string teamName, DateTime dateHired)
        {
            if (teamLeaderBirth >= dateHired)
            {
                throw new ArgumentOutOfRangeException("Date of birth of team leader cannot be bigger than date hired!");
            }
            
            var teamLeader = this.userFactory.CreateTeamLeader(teamLeaderName, teamLeaderBirth,
                                                               teamLeaderGender, dateHired, new Team(teamName));
            return string.Format(UserCreated, "Team Leader", teamLeaderName);
        }

        private string CreateBoss(string name, DateTime dateBirth, Gender sex, DateTime dateHired, decimal salary)
        {
            if (dateBirth >= dateHired)
            {
                throw new ArgumentOutOfRangeException("Date of birth of boss cannot be bigger than date hired!");
            }
            var boss = this.userFactory.CreateBoss(name, dateBirth, sex, dateHired, salary);

            return string.Format(UserCreated, "Boss", name);
        }

        private Gender GetGender(string genderAsString)
        {
            switch (genderAsString)
            {
                case "male":
                    return Gender.Male;
                case "female":
                    return Gender.Female;
                case "":
                    return Gender.Other;
                default:
                    throw new InvalidOperationException(InvalidGenderType);
            }
        }
    }
}
