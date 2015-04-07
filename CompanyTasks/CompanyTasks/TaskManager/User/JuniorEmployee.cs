/*
 A junior employee is a subordinate of some manager - it can be promoted and became a manager itself
 */

namespace TaskManager.User
{
    using System;

    using Enums;
    using User.Interfaces;

    public class JuniorEmployee : Employee, IIsPromotedToSenior
    {
        private const decimal InitSalary = 900;
        private const PositionType InitPosition = PositionType.Junior;

        public JuniorEmployee(string name, DateTime dateBirth, Gender sex, DateTime dateHired )
            : base(name, dateBirth, sex, InitPosition, dateHired, InitSalary)
        {
        }

        public SeniorEmployee PromotedToSinior(Employee employee, bool isPromoted)
        {
            if (employee.IsPromoted)
            {
                return new SeniorEmployee(employee.Name, employee.DateBirth, employee.Sex, employee.DateHired);
            }
            else return null;
        }
    }
}
