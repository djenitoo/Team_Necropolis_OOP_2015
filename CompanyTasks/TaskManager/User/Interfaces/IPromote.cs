namespace TaskManager.User.Interfaces
{
    public interface IPromote
    {
        /*
         A manager can decide to promote some of his subordinates employees - who will become a manager
         */

        void Promote(Employee employee);
    }
}
