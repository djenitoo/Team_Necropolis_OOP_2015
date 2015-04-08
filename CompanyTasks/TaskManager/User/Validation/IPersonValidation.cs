namespace TaskManager.User.Validation
{
    using System;

    public interface IPersonValidation
    {
        void ValidateName(string value);

        void ValidateDateOfBirth(System.DateTime value);

        void ValidateSalary(decimal value);
        
        void ValidateDateHired(DateTime value);

    }
}
