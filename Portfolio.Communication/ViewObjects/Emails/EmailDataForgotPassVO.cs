namespace Portfolio.Communication.ViewObjects.Emails
{
    public class EmailDataForgotPassVO
    {
        public List<string> Recipients { get; set; }
        public string NameUser { get; set; }
        public string EmailUser { get; set; }
        public string Username { get; set; }
        public string NewPassword { get; set; }
    }
}
