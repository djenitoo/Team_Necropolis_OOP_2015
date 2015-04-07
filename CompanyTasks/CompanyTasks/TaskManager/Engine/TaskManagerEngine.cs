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
        private const string CategoryExists = "Category with name {0} already exists!";
        private const string BossCreated = "Boss with name {0} was created!";
        private const string InvalidGenderType = "Invalid gender type!";


        private static readonly TaskManagerEngine SingleInstance = new TaskManagerEngine();

        private readonly UsersFactory userFactory;
        private readonly TasksFactory tasksFactory;
        //private readonly IDictionary<string, ICategory> categories;
        //private readonly IDictionary<string, IProduct> products;

        private TaskManagerEngine()
        {
            this.userFactory = new UsersFactory();
            this.tasksFactory = new TasksFactory();
            //this.categories = new Dictionary<string, ICategory>();
            //this.products = new Dictionary<string, IProduct>();
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
                   
                    return this.CreateBoss(bossName, bossBirth, bossGender);

                default:
                    return string.Format(InvalidCommand, command.Name);
            }
        }

        private string CreateBoss(string name, DateTime dateBirth, Gender sex)
        {
            var boss = this.userFactory.CreateBoss(name, dateBirth, sex);

            return string.Format(BossCreated, name);
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
