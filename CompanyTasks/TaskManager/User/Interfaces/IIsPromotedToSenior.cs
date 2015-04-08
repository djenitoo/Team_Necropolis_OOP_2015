namespace TaskManager.User.Interfaces
{
    public interface IIsPromotedToSenior
    {
        /*
         * If a manager promote some employee, then with the promote method
         * sets some bool IsPromoded variable to true - the employee should 
         * become a manager, so here there should be some MakeManager() method.
         */

        SeniorEmployee PromotedToSinior(Employee employee, bool isPromoted);
    }
}
