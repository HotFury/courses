using System;

namespace myProjectEvents
{
    class MailManager
    {
        public event EventHandler<NewMailEventArgs> NewMail;

        protected virtual void OnNewMail(NewMailEventArgs e)
        {
            //EventHandler<NewMailEventArgs> temp = NewMail;
            if (NewMail != null)
            {
                NewMail(this, e);
            }
        }

        public void SimulateNEwMail(string from, string to, string subject)
        {
            NewMailEventArgs e = new NewMailEventArgs(from, to, subject);
            OnNewMail(e);

        }
    }
    class Fax
    {
        public Fax(MailManager mm)
        {
            mm.NewMail += FaxMsg;
        }

        private void FaxMsg(Object sender, NewMailEventArgs e)
        {
            Console.WriteLine("Faxing mail message");
            Console.WriteLine("From: {0}. To: {1}. Subject: {2}.", e.From, e.To, e.Subject);
        }

        public void Unregister(MailManager mm)
        {
            mm.NewMail -= FaxMsg;

        }
    }
    class Program
    {
        static void Main()
        {
            MailManager mailManager = new MailManager();
            Fax fax = new Fax(mailManager);
            mailManager.SimulateNEwMail("lkasl@i.ua", "EPAM@gmail.com", "EventTest");
            mailManager.SimulateNEwMail("lkasl@i.ua", "KhPI@gmail.com", "EventTest");
            fax.Unregister(mailManager);
            mailManager.SimulateNEwMail("lkasl@i.ua", "Konan@mail.com", "EventTest");
            Console.ReadKey();
        }
    }
}
