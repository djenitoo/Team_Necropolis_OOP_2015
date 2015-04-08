namespace TaskManager.User.Interfaces
{
    using System.Collections.Generic;

    public interface IClient : IPerson
    {
        List<string>MyProjectsTodo { get; }
        void AddProject(string project);
        void RemoveProject(string project);
        void EmptyProjects();
        string ClientCompany { get; }
    }
}
