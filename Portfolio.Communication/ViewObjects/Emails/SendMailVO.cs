using System.Net.Mail;

namespace Portfolio.Communication.ViewObjects.Emails
{
    public class SendMailVO
    {
        public List<string> Recipients { get; set; } = new List<string>();
        public string Subject { get; set; }
        public string Body { get; set; }
        public AttachmentCollection Attachments { get; set; }
    }
}
