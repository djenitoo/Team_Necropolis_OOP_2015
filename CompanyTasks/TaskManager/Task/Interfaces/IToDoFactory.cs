namespace TaskManager.Task.Interfaces
{
    public interface IToDoFactory
    {
        IToDo CreateImportantToDo(string initTitle, string initDescription);

        IToDo CreateLowToDo(string initTitle, string initDescription);

        IToDo CreateMediumToDo(string initTitle, string initDescription);
    }
}
