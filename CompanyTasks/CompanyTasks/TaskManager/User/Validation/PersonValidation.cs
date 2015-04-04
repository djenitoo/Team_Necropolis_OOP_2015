﻿namespace TaskManager.User.Validation
{
    using System;

    using Common;

    public class PersonValidation : CommonValidation, IPersonValidation
    {
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
    }
}
