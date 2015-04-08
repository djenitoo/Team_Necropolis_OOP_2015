namespace TaskManager.Common
{
    using System;
    using System.Collections.Generic;

    using User.Interfaces;
    using Task.Interfaces;

    public interface IValidation
    {
        void StringLengthMinMax(string value,string param, int maxLength, int minLength);

        void NotNegativeIntegers<T>(T integer, string param) where T : struct, IComparable;

        void IntegerRange(int value, int max, int min, string errorMessage);

        void NotNullable(object obj, string param);

        
       
    }
}
