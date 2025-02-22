namespace Notfication_System
{
   public  delegate void NotficationHandler(string message);
    internal class Program
    {
        static void Main(string[] args)
        {
            NotficationSytem NS=new NotficationSytem();
            User u1 = new User("Shahd");
            u1.Subscribe(NS);
            User u2 = new User("Nour");
            u2.Subscribe(NS);
            NS.SendNotfication("Your First Notication");
            u2.UnSubscribe(NS);
            NS.SendNotfication("Your Second Notfication");
        }
    }
    public class NotficationSytem
    {
        public event NotficationHandler OnNotfication;

        public void SendNotfication(string message)
        {
            Console.WriteLine("New Notfication is sent");
            OnNotfication(message);
        }
    }
    public class User
    {
        public string Name { get; set; }
        public User(string name)
        {
            Name = name;
        }
        public void Subscribe(NotficationSytem ns)
        {
            Console.WriteLine($"{this.Name} has Subscribed");
            ns.OnNotfication += ReceivedMessage;
        }
        public void UnSubscribe(NotficationSytem ns)
        {
            Console.WriteLine($"{this.Name} has UnSubscribed ");
            ns.OnNotfication -= ReceivedMessage;
        }
        public void ReceivedMessage(string message)
        {
            Console.WriteLine($"{this.Name} Received Notfication >> {message}");
        }
    }
}
