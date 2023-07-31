namespace Portfolio.Communication.ViewObjects.Emails
{
    public class ConfigurationMailVO
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string EmailLogin { get; set; }
        public string EmailPass { get; set; }
    }
}
