namespace MailClient
{
    public class MailBox
    {
        public int Capacity { get; }
        public List<Mail> Inbox { get; }
        public List<Mail> Archive { get; }

        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }

        public void IncomingMail(Mail mail)
        {
            if (Inbox.Count < Capacity)
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender)
        {
            Mail mailToRemove = Inbox.FirstOrDefault(m => m.Sender == sender);
            if (mailToRemove != null)
            {
                Inbox.Remove(mailToRemove);
                return true;
            }
            return false;
        }

        public int ArchiveInboxMessages()
        {
            int messagesMoved = Inbox.Count;
            Archive.AddRange(Inbox);
            Inbox.Clear();
            return messagesMoved;
        }

        public string GetLongestMessage()
        {
            if (Inbox.Count == 0)
            {
                return string.Empty;
            }

            Mail longestMail = Inbox.OrderByDescending(m => m.Body.Length).First();
            return longestMail.ToString();
        }

        public string InboxView()
        {
            return "Inbox:\n" + string.Join("\n", Inbox.Select(mail => mail.ToString()));
        }


    }
}
