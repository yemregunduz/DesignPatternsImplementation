using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new();
            customerManager.MessageSenderBase = new EmailSender();
            customerManager.UpdateCustomer();

            Console.WriteLine("-------------------");

            customerManager.MessageSenderBase = new SmsSender();
            customerManager.UpdateCustomer();
            Console.ReadLine();
        }
    }
    class CustomerManager
    {
        public MessageSenderBase MessageSenderBase { get; set; }
        public void UpdateCustomer()
        {
            MessageSenderBase.Send(new Body() { Title="About the C#"});
            Console.WriteLine("Customer updated.");
        }
    }
    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Mesage saved");
        }
        public abstract void Send(Body body);
    }
    class Body
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
    class EmailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via Email sender", body.Title);
        }
    }
    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via Sms sender", body.Title);
        }
    }
}
