using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Core.Entities.Sql
{
    [Table("generic_type")]
    public class GenericType : BaseEntity
    {
        [Column("token")]
        public string Token { get; set; }
        [Column("value")]
        public string Value { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("value_bool")]
        public bool? ValueBool { get; set; }

        // prop navigation
        public virtual List<ExperienceWork> ExperiencesWorks { get; set; }
    }
}
