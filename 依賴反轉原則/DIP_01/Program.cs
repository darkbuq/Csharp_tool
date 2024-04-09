using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIP_01
{
    public interface IMessage
    {
        void SendMessage();
    }
    public class Email : IMessage
    {
        public void SendMessage()
        {
            Console.WriteLine("Send Email");
        }
    }
    public class SMS : IMessage
    {
        public void SendMessage()
        {
            Console.WriteLine("Send Sms");
        }
    }
    public class Notification
    {
        private IMessage _msg;
        public Notification(IMessage msg)
        {
            this._msg = msg;
        }
        public void Notify()
        {
            _msg.SendMessage();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Email email = new Email();
            Notification notify = new Notification(email);
            notify.Notify();

            SMS sms = new SMS();
            notify = new Notification(sms);
            notify.Notify();

            Console.ReadLine();
        }
    }
}
