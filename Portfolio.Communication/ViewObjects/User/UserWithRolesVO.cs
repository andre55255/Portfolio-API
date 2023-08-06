namespace Portfolio.Communication.ViewObjects.User
{
    public class UserWithRolesVO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public int AccessFailedCount { get; set; }
        public int? PortfolioSelectedId { get; set; }
        public List<string> Roles { get; set; }
    }
}
