
namespace TaskManager.User
{
    using System;

    using Enums;
    using Interfaces;

    public class SeniorEmployee : Employee, IIsPromotedToTeamLeader
    {
        private const decimal InitSalary = 2000M;
        private const PositionType InitPosition = PositionType.SeniorEmployee;

        public SeniorEmployee(string name, DateTime dateBirth, Gender sex, DateTime dateHired)
            : base(name, dateBirth, sex, InitPosition, dateHired, InitSalary)
        {

        }

        public TeamLeader PromotedToManager(Employee employee, bool isPromoted)
        {
            if (employee.IsPromoted)
            {
                return new TeamLeader(employee.Name, employee.DateBirth, employee.Sex, employee.DateHired, new Team(string.Format("{0}'s Team", employee.Name)));
            }
            else return null;
        }
    }
}
