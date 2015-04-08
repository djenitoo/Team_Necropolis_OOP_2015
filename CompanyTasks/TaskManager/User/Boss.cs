namespace TaskManager.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Enums;
    using User.Interfaces;

    public class Boss : Employee, IBoss
    {
        public ICollection<IClient> clients { get; private set; }

        public Boss(string name, DateTime dateBirth, Gender sex, DateTime dateHired, decimal salary)
            : base(name, dateBirth, sex, PositionType.Boss, dateHired, salary)
        {
            this.clients = new List<IClient>();
        }


        public void AddClient(IClient clientName)
        {
            clients.Add(clientName);
        }


        public void RemoveClient(IClient clientName)
        {
            clients.Remove(clientName);
        }


        public string ListOfClients()
        {
            var resultClients = clients
                .Select(x => x.Name + " " + x.MyProjectsTodo);
            var result = new StringBuilder();
            result.AppendLine("Clients:");
            result.AppendLine(string.Format("{0}", string.Join(", ", resultClients)));
            return result.ToString();
        }
    }
}
