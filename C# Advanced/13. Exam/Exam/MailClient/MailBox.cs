using System;
using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }

        public int Capacity { get; set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }

        public void IncomingMail ( Mail mail)
        {
            if (Inbox.Count < Capacity)
            {
                Inbox.Add(mail);
            }
        }
        public bool DeleteMail(string sender) => Inbox.Remove(Inbox.FirstOrDefault(x => x.Sender == sender));

        public string GetLongestMessage()
        {
            Mail longestMessage = Inbox.OrderByDescending(mail => mail.Body.Length).First();
            return longestMessage.ToString();
        }

        public int ArchiveInboxMessages()
        {
            int mailsMoved = 0;

            for (int i = Inbox.Count - 1; i >= 0; i--)
            {
                Mail mail = Inbox[i];
                Archive.Add(mail);
                Inbox.RemoveAt(i);
                mailsMoved++;
            }

            return mailsMoved;
        }

        public string InboxView()
        {
            StringBuilder sb = new();
            sb.AppendLine("Inbox:");

            Inbox.ForEach(x => sb.AppendLine(x.ToString()));

            return sb.ToString().Trim();
        }
    }
}
