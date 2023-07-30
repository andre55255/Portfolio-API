namespace Portfolio.Communication.ViewObjects.Utlis
{
    public class RequestDataVO
    {
        public bool IsAuth { get; set; }
        public UserAuthVO User { get; set; }
        public RequestHeadersVO Request { get; set; }
    }

    public class RequestHeadersVO
    {
        public string BaseUrlFront { get; set; }
    }

    public class UserAuthVO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }
}
