/*
 A manager is an employee with a list of subordinates employees 
 */

namespace TaskManager.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Enums;
    using User.Interfaces;
    using Task.Interfaces;

    public class TeamLeader : Employee, ITeamLeader, IPromote
    {
        private const decimal InitSalary = 3000M;
        private const PositionType InitPosition = PositionType.TeamLeader;

        public TeamLeader(string name, DateTime dateBirth, Gender sex, DateTime dateHired, Team initTeam)
            : base(name, dateBirth, sex, InitPosition, dateHired, InitSalary)
        {
            this.Team = initTeam;
        }

        public Team Team { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            var teamName = this.Team.TeamName;
                

            result.Append(base.ToString());
            result.AppendLine(string.Format("The {1}'s team - {0}", string.Join(", ", this.Team.EmployeeTasks.Keys.Select(x=> x.Name)), this.Name));
            result.AppendLine("Task's to Team:");
            result.AppendLine(string.Format("{0}", string.Join("\n", this.PersonalTodos)));
            return result.ToString();
        }

 
        public void Promote(Employee employee)
        {
            employee.IsPromoted = true;
        }
    }
}
