namespace TaskManager.User.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using User.Interfaces;
    using Task.Interfaces;

    public class PersonValidation : CommonValidation, IPersonValidation
    {
        private const string ErrMessWhenItemAlreadyExist = "The item already exist, you cant add it again!";
        private const string ErrMessWhenItemDoNotExist = "The item do not exist!";

        private const int MinLengthName = 2;
        private const int MaxLengthName = 30;
        private const int GeneralAgeValue = 18;

        public void ValidateName(string value)
        {
            this.NotNullable(value, "Name");

            this.StringLengthMinMax(value,"Name length", MaxLengthName, MinLengthName);
        }

        public void ValidateDateOfBirth(DateTime value)
        {
            if (value > DateTime.Now)
            {
                throw new ArgumentException("Date of birth can not be to bigger from current date!");
            }
        }

        public void ValidateDateHired(DateTime value)
        {
            if (value > DateTime.Now)
            {
                throw new ArgumentException("Date of hiring can not be to bigger from current date!");
            }
        }


        public void ValidateSalary(decimal value)
        {
            this.NotNegativeIntegers<decimal>(value, "Salary");
        }

        public void ItemAlreadyExist<T>(IEnumerable<T> placeToCheck, T itemToCheck) where T : IPerson, ISubtask
        {
            if (placeToCheck.Contains(itemToCheck))
            {
                throw new ArgumentException(ErrMessWhenItemAlreadyExist);
            }
        }

        public void ItemNotFound<T>(IEnumerable<T> placeToCheck, T itemToCheck)
        {
            if (!(placeToCheck.Contains(itemToCheck)))
            {
                throw new ArgumentException(ErrMessWhenItemDoNotExist);
            }
        }
    }
}
