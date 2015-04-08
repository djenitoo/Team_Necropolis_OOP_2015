namespace TaskManager.Task.Validation
{
    using Common;
    using Validation;
    using Interfaces;

    using System;

    public class TaskValidation : CommonValidation, ITaskValidation
    {
        private const int TitleMinLength = 3;
        private const int TitleMaxLength = 30;
        private const int DescMinLength = 20;
        private const int DescMaxLength = 1000;

        private const string ErrMessNotNullable = "Subtask can not be found!";
        private const string ErrMessWhenDaysToEndIsNegativeInteger = "Days to end must be positive integer!";

        public void ValidateTitle(string value, string param)
        {
            base.StringLengthMinMax(value,param, TitleMaxLength, TitleMinLength);
        }

        public void ValidateDescription(string value, string param)
        {
            base.StringLengthMinMax(value, param, DescMaxLength, DescMinLength);
        }

        public void ValidateDaysToEnd(int value, string param)
        {
            this.NotNegativeIntegers(value, param);
        }

        public void SubtaskNotFound(ISubtask subtask)
        {
            this.NotNullable(subtask,"Subtask");
        }
    }
}
