namespace TaskManager.User.Interfaces
{
    using System.Collections.Generic;

    public interface IBoss
    {
        ICollection<IClient> clients { get; }

        void AddClient(IClient clientName);

        void RemoveClient(IClient clientName);

        string ListOfClients();
    }
}
