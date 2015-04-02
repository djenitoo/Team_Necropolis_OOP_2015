﻿namespace TaskManager.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using User.Interfaces;

    public class Boss : Person, IBoss
    {
        public ICollection<Client> clients { get; private set; }

        public Boss(string name, DateTime dateBirth, Gender sex)
            : base(name, dateBirth, sex)
        {
            this.clients = new List<Client>();
        }


        public void addClient(Client clientName)
        {
            clients.Add(clientName);
        }


        public void removeClient(Client clientName)
        {
            clients.Remove(clientName);
        }


        public string listOfClients()
        {
            var resultClients = clients
                .Select(x => x.Name + " " + x.MyProjectTodo);
            var result = new StringBuilder();
            result.AppendLine("Clients:");
            result.AppendLine(string.Format("{0}", string.Join(", ", resultClients)));
            return result.ToString();
        }
    }
}