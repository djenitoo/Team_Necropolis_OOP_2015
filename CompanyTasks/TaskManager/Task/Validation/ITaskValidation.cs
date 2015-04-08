namespace TaskManager.Task.Validation
{
    using Common;
    using Interfaces;

    using System;

    public interface ITaskValidation 
    {
        void ValidateDaysToEnd(int value, string param);

        void ValidateDescription(string value, string param);

        void ValidateTitle(string value, string param);

        void SubtaskNotFound(ISubtask subtask);
    }
}
