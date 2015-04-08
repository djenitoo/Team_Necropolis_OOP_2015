namespace TaskManager.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Exception;
    using User.Interfaces;
    using Task.Interfaces;

    public abstract class CommonValidation : IValidation
    {
        private const string ErrMessNotNullable = "{0} can not be null!";
        private const string ErrMessWhenStringIsNevalid = "{0} must be to less from {1} or to bigger from {2}";
        private const string ErrMEssIntegerCanNotBeNegative = "Integer can not be negative";
        

        public void StringLengthMinMax(string value,string param, int maxLength, int minLength)
        {
            var currentLength = value.Length;

            TryRangeMinMax(maxLength, minLength,currentLength, param);
        }

        public void NotNegativeIntegers<T>(T integer,string param)  where T : struct, IComparable
        {
            if (integer.CompareTo(default(T)) < 0)
            {
                throw new ArgumentOutOfRangeException(param, ErrMEssIntegerCanNotBeNegative);
            }
        }

        public void IntegerRange(int value, int max, int min, string param)
        {
            TryRangeMinMax(max, min, value, param);
        }

        public  void NotNullable(object obj,string param)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(param, string.Format(ErrMessNotNullable, param));
            }
        }

        private static void TryRangeMinMax(int maxLength, int minLength, int currentLength, string param)
        {
            if (currentLength > maxLength || currentLength < minLength)
            {
                throw new InvalidRangeException<int>(maxLength, minLength, 
                        string.Format(ErrMessWhenStringIsNevalid , param , maxLength, minLength));
            }
        }

        
    }
}
