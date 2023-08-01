using Portfolio.Core.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Sql
{
    [Table("portfolio")]
    public class PortfolioConfig : BaseEntity
    {
        [Column("key_access")]
        public string KeyAccess { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("firstname")]
        public string Firstname { get; set; }

        [Column("lastname")]
        public string Lastname { get; set; }

        [Column("github_link")]
        public string GithubLink { get; set; }

        [Column("linkedin_link")]
        public string LinkedinLink { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("about_me")]
        public string AboutMe { get; set; }

        // Prop navigation
        public virtual List<AspNetUser> UsersAssociates { get; set; }
        public virtual List<PortfolioConfigUsersAssociate> PortolioUsersAssociates { get; set; }
        public virtual List<ExperienceWork> ExperiencesWorks { get; set; }
        public virtual List<ExperienceEducation> ExperiencesEducations{ get; set; }
        public virtual List<ContactMe> Contacts { get; set; }
        public virtual List<Project> Projects { get; set; }
    }
}
