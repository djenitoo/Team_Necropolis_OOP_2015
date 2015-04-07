namespace TaskManager.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using User;
    using User.Interfaces;
    using User.Enums;
    
    public class UsersFactory
    {
        public IBoss CreateBoss(string name, DateTime birthDate, Gender gender)
        {
            IBoss boss = new Boss(name, birthDate, gender);
            return boss;
        }

        public ITeamLeader CreateTeamLeader(string name, DateTime birthDate, Gender gender, DateTime dateHired, Team team)
        {
            ITeamLeader teamLeader = new TeamLeader(name, birthDate, gender, dateHired, team);
            return teamLeader;
        }


        public IEmployee CreateJuniorEmployee(string name, DateTime birthDate, Gender gender, DateTime dateHired)
        {
            IEmployee juniorEmployee = new JuniorEmployee(name, birthDate, gender, dateHired);
            return juniorEmployee;
        }

        public IEmployee CreateSeniorEmployee(string name, DateTime birthDate, Gender gender, DateTime dateHired)
        {
            IEmployee seniorEmployee = new SeniorEmployee(name, birthDate, gender, dateHired);
            return seniorEmployee;
        }

        public IClient CreateClient(string name, string company, IEnumerable<string> projects, DateTime birthdate, Gender gender)
        {
            IClient client = new Client(name, company, projects, birthdate, gender);
            return client;
        }
    }
}
